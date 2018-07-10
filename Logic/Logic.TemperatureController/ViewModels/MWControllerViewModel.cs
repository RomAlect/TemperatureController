using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.TemperatureController.Messages;
using System;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Threading;
using System.Windows;

namespace Logic.TemperatureController.ViewModels
{
    public class MWControllerViewModel : ViewModelBase
    {
        #region Fields


        #endregion

        #region Constructors
        public MWControllerViewModel()
        {
            MWOnCommand = new RelayCommand<bool>(SwitchMWOn);
            MWOffCommand = new RelayCommand<bool>(SwitchMWOff);
            Settings.IsPowerOnPropertyChanged += (sender, e) => IsPowerOn = Settings.IsPowerOn;
            Settings.TTLVoltagePropertyChanged += (sender, e) => TTLVoltage = Settings.TTLVoltage;
            Settings.MWFrequencyPropertyChanged += (sender, e) => MWFrequency = Settings.MWFrequency;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Provides the list of MW modes
        /// </summary>
        public ObservableCollection<string> MWModes => new ObservableCollection<string>
        {
           "Manual",
           "Frequency Sweep",
           "T1 Decay (Fast)"
        };

        /// <summary>
        /// Provides MWMode from Settins
        /// </summary>
        public string MWMode
        {
            get { return Settings.MWMode; }
            set { Settings.MWMode = value; }
        }

        /// <summary>
        /// Provides MWPower from Settings
        /// </summary>
        public int MWPower
        {
            get { return Settings.MWPower; }
            set
            {
                if (value < 0 || value > 400)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.MWPower),
                        "MW power should be in the range 0-400 mW");
                Settings.MWPower = value;
            }
        }

        /// <summary>
        /// Provides MWFrequency from Settings
        /// </summary>
        public double MWFrequency
        {
            get { return Settings.MWFrequency; }
            set
            {
                if (value < 93750)
                    Settings.MWFrequency = 93750;
                else if (value > 94250)
                    Settings.MWFrequency = 94250;
                else
                    Settings.MWFrequency = value;
            }
        }

        /// <summary>
        /// Provides MWFrequencyStep from Settings
        /// </summary>
        public double MWFrequencyStep
        {
            get { return Settings.MWFrequencyStep; }
            set
            {
                if (value < 93750 - Settings.MWFrequency)
                    Settings.MWFrequencyStep = 93750 - Settings.MWFrequency;
                else if (value > 94250 - Settings.MWFrequency)
                    Settings.MWFrequencyStep = 94250 - Settings.MWFrequency;
                else
                    Settings.MWFrequencyStep = value;
            }
        }

        public double TTLVoltage { get; private set; } = Settings.TTLVoltage;

        public double VoltageJump
        {
            get { return Settings.VoltageJump; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.VoltageJump),
                        "Voltage jump should not break the condition: OutputVoltage > 0");
                Settings.VoltageJump = value;
            }
        }

        public double CorrectionMWOnVoltage
        {
            get { return Settings.CorrectionMWOnVoltage; }
            set
            {
                if (value < 0 || value > Settings.PIDVmax)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.CorrectionMWOnVoltage),
                        "The correction output voltage should be decreased!");
                Settings.CorrectionMWOnVoltage = value;
            }
        }

        public double CorrectionMWOffVoltage
        {
            get { return Settings.CorrectionMWOffVoltage; }
            set
            {
                if (value < 0 || value > Settings.PIDVmax)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.CorrectionMWOffVoltage),
                        "The correction output voltage should be decreased!");
                Settings.CorrectionMWOffVoltage = value;
            }
        }

        public int CorrectionDelay
        {
            get { return Settings.CorrectionDelay; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.CorrectionDelay),
                        "Correction delay should be positive");
                Settings.CorrectionDelay = value;
            }
        }

        public bool IsPowerOn { get; private set; }

        #endregion

        #region Commands
        public RelayCommand<bool> MWOnCommand { get; private set; }
        public RelayCommand<bool> MWOffCommand { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Is called when ON button is pressed
        /// </summary>
        /// <param name="isTemperatureCorrection"></param>
        private void SwitchMWOn(bool isTemperatureCorrection)
        {
            Thread newThread = new Thread(() =>
                {
                    MessengerInstance.Send(
                        new MWSourceMessage(Settings.MWMode, isTemperatureCorrection, MWCommand.On));
                });
            newThread.Start();
        }

        /// <summary>
        /// Is called when OFF button is pressed
        /// </summary>
        /// <param name="isTemperatureCorrection"></param>
        private void SwitchMWOff(bool isTemperatureCorrection)
        {
            Thread newThread = new Thread(() =>
            {
                MessengerInstance.Send(
                    new MWSourceMessage(Settings.MWMode, isTemperatureCorrection, MWCommand.Off));
            });
            newThread.Start();
        }


        #endregion
    }
}
