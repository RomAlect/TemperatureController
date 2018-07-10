using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.TemperatureController.Messages;
using NationalInstruments;
using System;

namespace Logic.TemperatureController.ViewModels
{
    public class TemperatureHistoryViewModel : ViewModelBase
    {
        #region Fields 
        //private AnalogWaveform<double> _TemperatureData = new AnalogWaveform<double>(0);
        
        #endregion

        #region Constructors
        public TemperatureHistoryViewModel()
        {
            //When Settings.CurrentTemperature is changed, the next point is appended to the TemperatureData property
            Settings.CurrentTemperaturePropertyChanged += (sender, e) =>
            {
                TemperatureData.Append(new double[1] { Settings.CurrentTemperature } );
                CurrentTemperature = Settings.CurrentTemperature;
            };

            SetTemperatureCommand = new RelayCommand(
                () => MessengerInstance.Send(new PidTimerMessage(true))
                );
        }
        #endregion

        #region Properties

        public double DesiredTemperature
        {
            get { return Settings.DesiredTemperature; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.DesiredTemperature),
                        "Temperature should be positive");

                Settings.DesiredTemperature = value;
            }
        }

        public double CurrentTemperature { get; private set; } = Settings.CurrentTemperature;

        private double _Ymin;
        public double Ymin
        {
            get { return _Ymin; }
            set
            {
                if (value > _Ymax)
                    throw new ArithmeticException("The condition Ymin<Ymax is not fulfilled");

                _Ymin = value;
            }
        }

        private double _Ymax = 300;
        public double Ymax
        {
            get { return _Ymax; }
            set
            {
                if (value < _Ymin)
                    throw new ArithmeticException("The condition Ymin<Ymax is not fulfilled");

                _Ymax = value;
            }
        }

        public AnalogWaveform<double> TemperatureData
        {
            get { return Settings.TemperatureData; }
            set { Settings.TemperatureData = value; }
        }

        public RelayCommand SetTemperatureCommand { get; private set; }



        #endregion

        #region Methods
        
        #endregion
    }
}
