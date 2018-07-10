using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Logic.TemperatureController.ViewModels
{
    public class COMSettingsViewModel : ViewModelBase
    {
        #region Fields

        #endregion

        #region Constructors
        public COMSettingsViewModel()
        {
            CancelCommand = new RelayCommand<Window>(CloseWindow);
            OKCommand = new RelayCommand<Window>(ApplyCOMParameters);
        }
       
        #endregion

        #region Properties
        /// <summary>
        /// Provides the list of COM port names for the current computer
        /// </summary>
        public ObservableCollection<string> ListOfCOMPorts =>
            new ObservableCollection<string>(SerialPort.GetPortNames());

        public ObservableCollection<int> BaudRates => new ObservableCollection<int>{
            110, 300, 600, 1200, 2400, 4800, 9600, 14400,
            19200, 38400, 57600, 115200, 128000, 134400,
            153600, 230400, 256000,460800, 921600};

        public ObservableCollection<int> ListOfDataBits => new ObservableCollection<int> { 4, 5, 6, 7, 8 };

        public ObservableCollection<string> Parities =>
           new ObservableCollection<string>(Enum.GetNames(typeof(Parity)));

        public ObservableCollection<string> ListOfStopBits =>
           new ObservableCollection<string> { "None", "1", "1.5", "2" };

        public string CurrentCOMPortName { get; set; } = Settings.CurrentCOMPortName;
        public int BaudRate { get; set; } = Settings.COMPortBaudRate;
        public int DataBits { get; set; } = Settings.COMPortDataBits;
        public int Parity
        {
            get { return (int)Settings.COMPortParity; }
            set { Settings.COMPortParity = (Parity)value; }
        }
        public int StopBits
        {
            get { return (int)Settings.COMPortStopBits; }
            set { Settings.COMPortStopBits = (StopBits)value; }
        }
        #endregion

        #region Commands
        public RelayCommand<Window> CancelCommand { get; private set; }
        public RelayCommand<Window> OKCommand { get; private set; }
        #endregion

        #region Methods
        private void CloseWindow(Window window)
        {
            CurrentCOMPortName = Settings.CurrentCOMPortName;
            BaudRate = Settings.COMPortBaudRate;
            DataBits = Settings.COMPortDataBits;
            Parity = (int)Settings.COMPortParity;
            StopBits = (int)Settings.COMPortStopBits;

            window?.Close();
        }

        private void ApplyCOMParameters(Window window)
        {
            Settings.CurrentCOMPortName = CurrentCOMPortName;
            Settings.COMPortBaudRate = BaudRate;
            Settings.COMPortDataBits = DataBits;
            Settings.COMPortParity = (Parity)Parity;
            Settings.COMPortStopBits = (StopBits)StopBits;

            window?.Close();
        }


        #endregion

    }
}
