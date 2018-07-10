using System;
using System.Windows.Threading;
using Logic.TemperatureController.Models;
using Logic.TemperatureController.Messages;
using GalaSoft.MvvmLight.Messaging;
using System.Threading;
using static Logic.TemperatureController.Settings;
using System.IO.Ports;
using System.Windows;

namespace Logic.TemperatureController
{
    /// <summary>
    /// TimersManager class serves as a message listener.
    /// It manages all timers used in the application
    /// </summary>
    public class TimersManager
    {
        #region Fields
        //Declare timers
        private DispatcherTimer _TemperatureTimer;
        private DispatcherTimer _PidTimer;
        private DispatcherTimer _TTLTimer;

        //Declare models
        private TemperatureCalculatorModel _TemperatureCalculator;
        private PidControllerModel _PidController;
        private DaqBoardModel _DaqBoard;
        private MWSourceModel _MWSource;

        //Declare serial port
        private SerialPort _SerialPort;

        private double _VTTL;
        private double _VTTL_prev;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes an instance of TimersManager 
        /// </summary>
        public TimersManager()
        {
            RegisterMessages();
            InitializeTimers();
            InitializeCOMPort();
            InitializeModels();
        }
        #endregion

        #region Properties
        /// <summary>
        /// We need this property to create an instance of TimersManager through binding to this property from MainWindow.
        /// </summary>
        public bool BindableProperty => true;
        #endregion

        #region Events
        /// <summary>
        /// This event corresponds to change of the TTL voltage from NMR console. 
        /// It allows applying TTL logic in the code
        /// </summary>
        public event Action TTLVoltageChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Registers messages from the default messenger of MVVM Light framework
        /// </summary>
        private void RegisterMessages()
        {
            Messenger.Default.Register<PidTimerMessage>(
               this,
               msg =>
               {
                   if (msg.IsTimerOn)
                       _PidTimer.Start();
                   else
                       _PidTimer.Stop();
               });

            Messenger.Default.Register<TemperatureTimerMessage>(
               this,
               msg =>
               {
                   if (msg.IsTimerOn)
                       _TemperatureTimer.Start();
                   else
                       _TemperatureTimer.Stop();
               });

            Messenger.Default.Register<VoltageControlMessage>(
               this,
               msg =>
               {
                   _PidTimer.Stop();
                   OutputVoltage = msg.ManualOutputVoltage;
                   _DaqBoard.Write(TemperatureDaqOutput, OutputVoltage);
               });

            Messenger.Default.Register<TemperatureCorrectionMessage>(
                this, OnTemperatureCorrection);

            Messenger.Default.Register<MWSourceMessage>(
               this, MWSourceOperation);
        }

        /// <summary>
        /// Initializes timers defining their intervals and callback methods
        /// </summary>
        private void InitializeTimers()
        {
            _TemperatureTimer = new DispatcherTimer();
            _TemperatureTimer.Tick += (sender, e) =>
            {
                InputVoltage = _DaqBoard.Read(TemperatureDaqInput);
                CurrentTemperature = _TemperatureCalculator.GetTemperature(InputVoltage);
            };
            _TemperatureTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);

            _PidTimer = new DispatcherTimer();
            _PidTimer.Tick += (sender, e) =>
            {
                OutputVoltage = _PidController.CalculateOutputVoltage(CurrentTemperature);
                _DaqBoard.Write(TemperatureDaqOutput, OutputVoltage);
            };
            _PidTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);

            _TTLTimer = new DispatcherTimer();
            _TTLTimer.Tick += OnTTLTimer;
            _TTLTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        /// <summary>
        /// Initializes the serial port and sibscribes its properties to corresponding events from Settings
        /// </summary>
        private void InitializeCOMPort()
        {
            _SerialPort = new SerialPort();
            _SerialPort.PortName = CurrentCOMPortName;
            CurrentCOMPortNamePropertyChanged += (sender, e) => _SerialPort.PortName = CurrentCOMPortName;
            _SerialPort.DataBits = COMPortDataBits;
            COMPortDataBitsPropertyChanged += (sender, e) => _SerialPort.DataBits = COMPortDataBits;
            _SerialPort.StopBits = COMPortStopBits;
            COMPortStopBitsPropertyChanged += (sender, e) => _SerialPort.StopBits = COMPortStopBits;
            _SerialPort.Parity = COMPortParity;
            COMPortParityPropertyChanged += (sender, e) => _SerialPort.Parity = COMPortParity;
            _SerialPort.BaudRate = COMPortBaudRate;
            COMPortBaudRatePropertyChanged += (sender, e) => _SerialPort.BaudRate = COMPortBaudRate;
            _SerialPort.ReadTimeout = 5000;
            _SerialPort.WriteTimeout = 5000;
        }

        private void InitializeModels()
        {
            _TemperatureCalculator = new TemperatureCalculatorModel();
            _PidController = new PidControllerModel();

            _DaqBoard = new DaqBoardModel(Device);
            DevicePropertyChanged += (sender, e) => _DaqBoard.Device = Device;

            _MWSource = new MWSourceModel(_SerialPort);
            MWFrequencyPropertyChanged += (sender, e) => _MWSource.SendMWCommand(MWCommand.SetFrequency);
            MWPowerPropertyChanged += (sender, e) => _MWSource.SendMWCommand(MWCommand.SetPower);
        }

        /// <summary>
        /// Callback method invoked by messenger, when new TemperatureCorrectionMessage appears
        /// </summary>
        private void OnTemperatureCorrection(TemperatureCorrectionMessage msg)
        {
            if (msg.CorrectionCommand == MWCommand.On)
            {
                _PidTimer.Stop();
                if (VoltageJump > OutputVoltage)
                    OutputVoltage = 0;
                else
                    OutputVoltage -= VoltageJump;
                _DaqBoard.Write(TemperatureDaqOutput, OutputVoltage);
                Thread.Sleep(CorrectionDelay);
                OutputVoltage = CorrectionMWOnVoltage;
                _DaqBoard.Write(TemperatureDaqOutput, OutputVoltage);
                _PidTimer.Start();
            }

            if (msg.CorrectionCommand == MWCommand.Off)
            {
                _PidTimer.Stop();
                if (OutputVoltage + VoltageJump > PIDVmax)
                    OutputVoltage = PIDVmax;
                else
                    OutputVoltage += VoltageJump;
                _DaqBoard.Write(TemperatureDaqOutput, OutputVoltage);
                Thread.Sleep(CorrectionDelay);
                OutputVoltage = CorrectionMWOffVoltage;
                _DaqBoard.Write(TemperatureDaqOutput, OutputVoltage);
                _PidTimer.Start();
            }
        }

        /// <summary>
        /// Callback method of the TTL timer
        /// </summary>
        private void OnTTLTimer(object sender, EventArgs e)
        {
            TTLVoltage = _DaqBoard.Read(MWDaqInput);
            _VTTL_prev = _VTTL;
            _VTTL = TTLVoltage;

            if (_VTTL < 2.0 && Math.Abs(_VTTL - _VTTL_prev) > 3.0)
            {
                TTLVoltageChanged?.Invoke();
            }
        }

        /// <summary>
        /// Callback method invoked by messenger, when new MWSourceMessage appears
        /// </summary>
        private void MWSourceOperation(MWSourceMessage msg)
        {
            switch (msg.MWCommand)
            {
                case MWCommand.On:
                    {
                        MWSourceOn(msg.MWMode, msg.IsTemperatureCorrection);
                    }

                    break;

                case MWCommand.Off:
                    {
                        MWSourceOff(msg.MWMode, msg.IsTemperatureCorrection);
                    }

                    break;
            }
        }


        private void MWSourceOn(string mwMode, bool isTemperatureCorrection)
        {
            switch (mwMode)
            {
                case "Manual":
                    ManualOn(isTemperatureCorrection);
                    break;

                case "Frequency Sweep":
                    FrequencySweepOn();
                    break;

                case "T1 Decay (Fast)":
                    T1DecayOn(isTemperatureCorrection);
                    break;
            }
        }

        private void MWSourceOff(string mwMode, bool isTemperatureCorrection)
        {
            switch (mwMode)
            {
                case "Manual":
                    ManualOff(isTemperatureCorrection);
                    break;

                case "Frequency Sweep":
                    FrequencySweepOff();
                    break;

                case "T1 Decay (Fast)":
                    T1DecayOff(isTemperatureCorrection);
                    break;
            }
        }

        private void ManualOn(bool isTemperatureCorrection)
        {
            try
            {
                if (!_MWSource.IsMwOn())
                {
                    _MWSource.SendMWCommand(MWCommand.SetPower);
                    _MWSource.SendMWCommand(MWCommand.SetFrequency);
                    _MWSource.SendMWCommand(MWCommand.On);
                }

                if (isTemperatureCorrection)
                    OnTemperatureCorrection(new TemperatureCorrectionMessage(MWCommand.On));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManualOff(bool isTemperatureCorrection)
        {
            try
            {
                if (_MWSource.IsMwOn())
                {
                    _MWSource.SendMWCommand(MWCommand.Off);
                }
                if (isTemperatureCorrection)
                    OnTemperatureCorrection(new TemperatureCorrectionMessage(MWCommand.Off));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrequencySweepOn()
        {
            try
            {
                if (!_MWSource.IsMwOn())
                {
                    _MWSource.SendMWCommand(MWCommand.SetPower);
                    _MWSource.SendMWCommand(MWCommand.SetFrequency);
                    _MWSource.SendMWCommand(MWCommand.On);
                }

                if (!_TTLTimer.IsEnabled)
                    _TTLTimer.Start();

                TTLVoltageChanged = null;
                TTLVoltageChanged += () =>
                {
                    MWFrequency += MWFrequencyStep;
                    _MWSource.SendMWCommand(MWCommand.SetFrequency);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrequencySweepOff()
        {
            try
            {
                if (_MWSource.IsMwOn())
                {
                    _MWSource.SendMWCommand(MWCommand.Off);
                }

                if (_TTLTimer.IsEnabled)
                {
                    _TTLTimer.Stop();
                    Thread.Sleep(5);
                    TTLVoltage = double.NaN;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void T1DecayOn(bool isTemperatureCorrection)
        {
            try
            {
                if (!_MWSource.IsMwOn())
                {
                    _MWSource.SendMWCommand(MWCommand.SetPower);
                    _MWSource.SendMWCommand(MWCommand.SetFrequency);
                    _MWSource.SendMWCommand(MWCommand.On);
                }

                if (!_TTLTimer.IsEnabled)
                    _TTLTimer.Start();

                TTLVoltageChanged = null;
                TTLVoltageChanged += () =>
                {
                    _MWSource.SendMWCommand(MWCommand.Off);
                    _TTLTimer.Stop();
                    if (isTemperatureCorrection)
                        OnTemperatureCorrection(new TemperatureCorrectionMessage(MWCommand.On));
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void T1DecayOff(bool isTemperatureCorrection)
        {
            if (!_TTLTimer.IsEnabled)
                _TTLTimer.Start();

            try
            {
                TTLVoltageChanged = null;
                TTLVoltageChanged += () =>
                {
                    _MWSource.SendMWCommand(MWCommand.Off);
                    _TTLTimer.Stop();
                    if (isTemperatureCorrection)
                        OnTemperatureCorrection(new TemperatureCorrectionMessage(MWCommand.Off));
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }
        #endregion
    }
}
