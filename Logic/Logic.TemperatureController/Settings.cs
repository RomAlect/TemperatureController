using NationalInstruments;
using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows;

namespace Logic.TemperatureController
{
    public enum MWCommand
    {
        SetPower,
        SetFrequency,
        On,
        Off
    }

    public static class Settings
    {
        #region Methods

        /// <summary>
        /// Performs SOAP serialization of the Settings class 
        /// </summary>
        /// <param name="filename"> </param>
        /// <returns>true if serialization was successful, otherwise false</returns>
        public static bool Save(string filename)
        {
            try
            {
                FieldInfo[] fields = typeof(Settings)
                     .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                     .Except(
                         typeof(Settings)
                         .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                         .Where(field => field.IsDefined(typeof(NonSerializedAttribute), false))
                         )
                     .ToArray();

                object[,] a = new object[fields.Length, 2];
                int i = 0;
                foreach (FieldInfo field in fields)
                {
                    a[i, 0] = field.Name;
                    a[i, 1] = field.GetValue(null);
                    i++;
                };
                Stream f = File.Open(filename, FileMode.Create);
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(f, a);
                f.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Performs deserialization of the "filename" file into static Settings class
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool Load(string filename)
        {
            try
            {
                FieldInfo[] fields = typeof(Settings)
                    .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                    .Except(
                        typeof(Settings)
                        .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                        .Where(field => field.IsDefined(typeof(NonSerializedAttribute), false))
                        )
                    .ToArray();
                object[,] a;
                Stream f = File.Open(filename, FileMode.Open);
                SoapFormatter formatter = new SoapFormatter();
                a = formatter.Deserialize(f) as object[,];
                f.Close();
                if (a.GetLength(0) != fields.Length) return false;
                int i = 0;
                foreach (FieldInfo field in fields)
                {
                    if (field.Name == (a[i, 0] as string))
                    {
                        if (a[i, 1] != null)
                            field.SetValue(null, a[i, 1]);
                    }
                    i++;
                };
                return true;
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;

            }
        }

        #endregion

        #region Devices and Inputs/Outputs

        
        private static string _Device = "dev2";
        [field: NonSerialized]
        public static event EventHandler DevicePropertyChanged;
        public static string Device
        {
            get { return _Device; }
            set
            {
                _Device = value;
                DevicePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static string _TemperatureDaqInput = "ai0";
        [field: NonSerialized]
        public static event EventHandler TemperatureDaqInputPropertyChanged;
        public static string TemperatureDaqInput
        {
            get { return _TemperatureDaqInput; }
            set
            {
                _TemperatureDaqInput = value;
                TemperatureDaqInputPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static string _TemperatureDaqOutput = "ao0";
        [field: NonSerialized]
        public static event EventHandler TemperatureDaqOutputPropertyChanged;
        public static string TemperatureDaqOutput
        {
            get { return _TemperatureDaqOutput; }
            set
            {
                _TemperatureDaqOutput = value;
                TemperatureDaqOutputPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static string _MWDaqInput = "ai0";
        [field: NonSerialized]
        public static event EventHandler MWDaqInputPropertyChanged;
        public static string MWDaqInput
        {
            get { return _MWDaqInput; }
            set
            {
                _MWDaqInput = value;
                MWDaqInputPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        #endregion

        #region COM port
        [NonSerialized]
        private static string _CurrentCOMPortName = SerialPort.GetPortNames()[SerialPort.GetPortNames().Length - 1];
        [field: NonSerialized]
        public static event EventHandler CurrentCOMPortNamePropertyChanged;
        public static string CurrentCOMPortName
        {
            get { return _CurrentCOMPortName; }
            set
            {
                _CurrentCOMPortName = value;
                CurrentCOMPortNamePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }
        
        private static int _COMPortBaudRate = 115200;
        [field: NonSerialized]
        public static event EventHandler COMPortBaudRatePropertyChanged;
        public static int COMPortBaudRate
        {
            get { return _COMPortBaudRate; }
            set
            {
                _COMPortBaudRate = value;
                COMPortBaudRatePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static Parity _COMPortParity = Parity.None;
        [field: NonSerialized]
        public static event EventHandler COMPortParityPropertyChanged;
        public static Parity COMPortParity
        {
            get { return _COMPortParity; }
            set
            {
                _COMPortParity = value;
                COMPortParityPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static int _COMPortDataBits = 8;
        [field: NonSerialized]
        public static event EventHandler COMPortDataBitsPropertyChanged;
        public static int COMPortDataBits
        {
            get { return _COMPortDataBits; }
            set
            {
                _COMPortDataBits = value;
                COMPortDataBitsPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static StopBits _COMPortStopBits = StopBits.One;
        [field: NonSerialized]
        public static event EventHandler COMPortStopBitsPropertyChanged;
        public static StopBits COMPortStopBits
        {
            get { return _COMPortStopBits; }
            set
            {
                _COMPortStopBits = value;
                COMPortStopBitsPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }
        #endregion

        #region Synchronization range
        private static double _Vmin;
        [field: NonSerialized]
        public static event EventHandler VminPropertyChanged;
        public static double Vmin
        {
            get { return _Vmin; }
            set
            {
                _Vmin = value;
                VminPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _Vmax;
        [field: NonSerialized]
        public static event EventHandler VmaxPropertyChanged;
        public static double Vmax
        {
            get { return _Vmax; }
            set
            {
                _Vmax = value;
                VmaxPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _Tmin;
        [field: NonSerialized]
        public static event EventHandler TminPropertyChanged;
        public static double Tmin
        {
            get { return _Tmin; }
            set
            {
                _Tmin = value;
                TminPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _Tmax;
        [field: NonSerialized]
        public static event EventHandler TmaxPropertyChanged;
        public static double Tmax
        {
            get { return _Tmax; }
            set
            {
                _Tmax = value;
                TmaxPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _Rmin;
        [field: NonSerialized]
        public static event EventHandler RminPropertyChanged;
        public static double Rmin
        {
            get { return _Rmin; }
            set
            {
                _Rmin = value;
                RminPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _Rmax;
        [field: NonSerialized]
        public static event EventHandler RmaxPropertyChanged;
        public static double Rmax
        {
            get { return _Rmax; }
            set
            {
                _Rmax = value;
                RmaxPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static bool _IsTempRange = true;
        [field: NonSerialized]
        public static event EventHandler IsTempRangePropertyChanged;
        public static bool IsTempRange
        {
            get { return _IsTempRange; }
            set
            {
                _IsTempRange = value;
                IsTempRangePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static bool _IsResistanceRange = false;
        [field: NonSerialized]
        public static event EventHandler IsResistanceRangePropertyChanged;
        public static bool IsResistanceRange
        {
            get { return _IsResistanceRange; }
            set
            {
                _IsResistanceRange = value;
                IsResistanceRangePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        #endregion

        #region PID Control
        private static double _Kp;
        [field: NonSerialized]
        public static event EventHandler KpPropertyChanged;
        public static double Kp
        {
            get { return _Kp; }
            set
            {
                _Kp = value;
                KpPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _Ki;
        [field: NonSerialized]
        public static event EventHandler KiPropertyChanged;
        public static double Ki
        {
            get { return _Ki; }
            set
            {
                _Ki = value;
                KiPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _Kd;
        [field: NonSerialized]
        public static event EventHandler KdPropertyChanged;
        public static double Kd
        {
            get { return _Kd; }
            set
            {
                _Kd = value;
                KdPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _PIDScale;
        [field: NonSerialized]
        public static event EventHandler PIDScalePropertyChanged;
        public static double PIDScale
        {
            get { return _PIDScale; }
            set
            {
                _PIDScale = value;
                PIDScalePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _PIDVmin;
        [field: NonSerialized]
        public static event EventHandler PIDVminPropertyChanged;
        public static double PIDVmin
        {
            get { return _PIDVmin; }
            set
            {
                _PIDVmin = value;
                PIDVminPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _PIDVmax;
        [field: NonSerialized]
        public static event EventHandler PIDVmaxPropertyChanged;
        public static double PIDVmax
        {
            get { return _PIDVmax; }
            set
            {
                _PIDVmax = value;
                PIDVmaxPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }


        #endregion

        #region Temperature history

        [NonSerialized]
        private static double _DesiredTemperature;
        [field: NonSerialized]
        public static event EventHandler DesiredTemperaturePropertyChanged;
        public static double DesiredTemperature
        {
            get { return _DesiredTemperature; }
            set
            {
                _DesiredTemperature = value;
                DesiredTemperaturePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static double _CurrentTemperature = double.NaN;
        [field: NonSerialized]
        public static event EventHandler CurrentTemperaturePropertyChanged;
        public static double CurrentTemperature
        {
            get { return _CurrentTemperature; }
            set
            {
                _CurrentTemperature = value;
                CurrentTemperaturePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        
        [NonSerialized]
        private static AnalogWaveform<double> _TemperatureData = new AnalogWaveform<double>(0);
        [field: NonSerialized]
        public static event EventHandler TemperatureDataPropertyChanged;
        public static AnalogWaveform<double> TemperatureData
        {
            get { return _TemperatureData; }
            set
            {
                _TemperatureData = value;
                TemperatureDataPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }
        #endregion

        #region Voltage control

        [NonSerialized]
        private static double _InputVoltage = double.NaN;
        [field: NonSerialized]
        public static event EventHandler InputVoltagePropertyChanged;
        public static double InputVoltage
        {
            get { return _InputVoltage; }
            set
            {
                _InputVoltage = value;
                InputVoltagePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static double _OutputVoltage;
        [field: NonSerialized]
        public static event EventHandler OutputVoltagePropertyChanged;
        public static double OutputVoltage
        {
            get { return _OutputVoltage; }
            set
            {
                _OutputVoltage = value;
                OutputVoltagePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static double _VoltageJump;
        [field: NonSerialized]
        public static event EventHandler VoltageJumpPropertyChanged;
        public static double VoltageJump
        {
            get { return _VoltageJump; }
            set
            {
                _VoltageJump = value;
                VoltageJumpPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static int _CorrectionDelay;
        [field: NonSerialized]
        public static event EventHandler CorrectionDelayPropertyChanged;
        public static int CorrectionDelay
        {
            get { return _CorrectionDelay; }
            set
            {
                _CorrectionDelay = value;
                CorrectionDelayPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static double _CorrectionMWOnVoltage;
        [field: NonSerialized]
        public static event EventHandler CorrectionMWOnVoltagePropertyChanged;
        public static double CorrectionMWOnVoltage
        {
            get { return _CorrectionMWOnVoltage; }
            set
            {
                _CorrectionMWOnVoltage = value;
                CorrectionMWOnVoltagePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static double _CorrectionMWOffVoltage;
        [field: NonSerialized]
        public static event EventHandler CorrectionMWOffVoltagePropertyChanged;
        public static double CorrectionMWOffVoltage
        {
            get { return _CorrectionMWOffVoltage; }
            set
            {
                _CorrectionMWOffVoltage = value;
                CorrectionMWOffVoltagePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        #endregion

        #region MW control
        [NonSerialized]
        private static bool _IsMWOn;
        [field: NonSerialized]
        public static event EventHandler IsMWOnPropertyChanged;
        public static bool IsMWOn
        {
            get { return _IsMWOn; }
            set
            {
                _IsMWOn = value;
                IsMWOnPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static string _MWMode = "Manual";
        [field: NonSerialized]
        public static event EventHandler MWModePropertyChanged;
        public static string MWMode
        {
            get { return _MWMode; }
            set
            {
                _MWMode = value;
                MWModePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }


        private static int _MWPower = 50;
        [field: NonSerialized]
        public static event EventHandler MWPowerPropertyChanged;
        public static int MWPower
        {
            get { return _MWPower; }
            set
            {
                _MWPower = value;
                MWPowerPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        private static double _MWFrequency = 94000;
        [field: NonSerialized]
        public static event EventHandler MWFrequencyPropertyChanged;
        public static double MWFrequency
        {
            get { return _MWFrequency; }
            set
            {
                _MWFrequency = value;
                MWFrequencyPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static double _MWFrequencyStep;
        [field: NonSerialized]
        public static event EventHandler MWFrequencyStepPropertyChanged;
        public static double MWFrequencyStep
        {
            get { return _MWFrequencyStep; }
            set
            {
                _MWFrequencyStep = value;
                MWFrequencyStepPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        [NonSerialized]
        private static double _TTLVoltage = double.NaN;
        [field: NonSerialized]
        public static event EventHandler TTLVoltagePropertyChanged;
        public static double TTLVoltage
        {
            get { return _TTLVoltage; }
            set
            {
                _TTLVoltage = value;
                TTLVoltagePropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static string MWStateMessage { get; set; } = String.Empty;
        #endregion

        [NonSerialized]
        private static bool _IsPowerOn;
        [field: NonSerialized]
        public static event EventHandler IsPowerOnPropertyChanged;
        public static bool IsPowerOn
        {
            get { return _IsPowerOn; }
            set
            {
                _IsPowerOn = value;
                IsPowerOnPropertyChanged?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}
