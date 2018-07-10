using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using Logic.TemperatureController.Messages;
using Microsoft.Win32;
using System.IO;

namespace Logic.TemperatureController.ViewModels
{

    public class MainViewModel : ViewModelBase
    {
        #region Fields       
        private ObservableCollection<string> _ListOfDevices = new ObservableCollection<string>
        {
            "dev0", "dev1", "dev2",
            "dev3", "dev4", "dev5",
            "dev6", "dev7", "dev8"
        };
        private ObservableCollection<string> _ListOfInputs = new ObservableCollection<string>
        {
            "ai0", "ai1", "ai2",
            "ai3", "ai4", "ai5",
            "ai6", "ai7", "ai8",
            "ai9", "ai10", "ai11",
            "ai12", "ai13", "ai14",
            "ai15", "ai16", "ai17",
            "ai18", "ai19", "ai20"
        };
        private ObservableCollection<string> _ListOfOutputs = new ObservableCollection<string>
        {
            "ao0", "ao1", "ao2", "ao3"
        };
        #endregion        

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                WindowTitle = "Temperature Controller (Design)";
            }
            else
            {
                WindowTitle = "Temperature Controller";
            }

            InitializeCommands();

            Settings.Load("Settings.soap");            
        }


        private void InitializeCommands()
        {
            ClosingCommand = new RelayCommand<CancelEventArgs>(
               new Action<CancelEventArgs>(Closing_MainWindow));

            ExitCommand = new RelayCommand(new Action(Exit_Application));

            PowerOnCommand = new RelayCommand(
                () => 
                {
                    Settings.IsPowerOn = true;
                    MessengerInstance.Send(new TemperatureTimerMessage(true));
                }
                );

            PowerOffCommand = new RelayCommand(
                () => 
                {
                    Settings.IsPowerOn = false;
                    MessengerInstance.Send(new TemperatureTimerMessage(false));
                }
                );

            OpenCOMSettingsCommand = new RelayCommand(
                () => MessengerInstance.Send(new COMSettingsMessage(true))
                );

            OpenHelpCommand = new RelayCommand(
               () => MessengerInstance.Send(new HelpMessage(true))
               );

            SaveHistoryCommand = new RelayCommand(OnSaveHistory);

        }
        #endregion
       
        #region Properties
        public string WindowTitle { get; private set; }

        public RelayCommand<CancelEventArgs> ClosingCommand { get; private set; }

        public RelayCommand ExitCommand { get; private set; }

        public RelayCommand SaveHistoryCommand { get; private set; }

        public RelayCommand OpenHelpCommand { get; private set; }

        public RelayCommand PowerOnCommand { get; private set; }

        public RelayCommand PowerOffCommand { get; private set; }

        public RelayCommand OpenCOMSettingsCommand { get; private set; }

        /// <summary>
        /// Provides the list of DAQ devices
        /// </summary>
        public ObservableCollection<string> ListOfDevices => _ListOfDevices;

        /// <summary>
        /// Provides the list of DAQ inputs
        /// </summary>
        public ObservableCollection<string> ListOfInputs => _ListOfInputs;

        /// <summary>
        /// Provides the list of DAQ outputs
        /// </summary>
        public ObservableCollection<string> ListOfOutputs => _ListOfOutputs;

        /// <summary>
        /// Current device # to work with
        /// </summary>        
        public string Device
        {
            get { return Settings.Device; }
            set { Settings.Device = value; }
        }

        /// <summary>
        /// Current DAQ input to calculate temperature using voltage from it
        /// </summary>        
        public string TemperatureDaqInput
        {
            get { return Settings.TemperatureDaqInput; }
            set { Settings.TemperatureDaqInput = value; }
        }

        /// <summary>
        /// Current DAQ output, whose voltage will be set as PID output
        /// </summary>
        public string TemperatureDaqOutput
        {
            get { return Settings.TemperatureDaqOutput; }
            set { Settings.TemperatureDaqOutput = value; }
        }

        /// <summary>
        /// Current DAQ input to read TTL from NMR console
        /// </summary>        
        public string MWDaqInput
        {
            get { return Settings.MWDaqInput; }
            set { Settings.MWDaqInput = value; }
        }
        #endregion

        #region Methods

        private void Closing_MainWindow(CancelEventArgs e)
        {
            string msg = "Do you want to save all settings \nto use them at future app launching?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Closing Temperature Controller",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }

            if (result == MessageBoxResult.Yes)
            {
                Settings.Save("Settings.soap");
            }
            
            
        }

        private void Exit_Application()
        {
            Application.Current.MainWindow.Close();
        }

        private void OnSaveHistory()
        {
            try
            {
                double[] data = Settings.TemperatureData.GetRawData();
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "txt";
                saveDialog.AddExtension = true;
                saveDialog.FileName = "TemperatureHistory";
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveDialog.OverwritePrompt = true;
                saveDialog.Title = "Temperature Controller";
                saveDialog.ValidateNames = true;

                if (saveDialog.ShowDialog().Value)
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        foreach (var i in data)
                        {
                            writer.WriteLine(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion
    }
}