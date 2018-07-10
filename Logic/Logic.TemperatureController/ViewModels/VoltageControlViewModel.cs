using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.TemperatureController.Messages;
using System;

namespace Logic.TemperatureController.ViewModels
{
    public class VoltageControlViewModel : ViewModelBase
    {
        public VoltageControlViewModel()
        {
            Settings.InputVoltagePropertyChanged += (sender, e) => InputVoltage = Settings.InputVoltage;

            Settings.OutputVoltagePropertyChanged += (sender, e) => OutputVoltage = Settings.OutputVoltage;

            ResetCommand = new RelayCommand(
                () => MessengerInstance.Send(new VoltageControlMessage(0)));

        }

        public double InputVoltage { get; private set; } = Settings.InputVoltage;

        public double OutputVoltage { get; private set; }

        public double ManualOutput
        {
            get { return Settings.OutputVoltage; }
            set
            {
                if (value > 10 || value < 0)
                    throw new ArgumentOutOfRangeException("Output voltage should be in the range 0-10V");

                MessengerInstance.Send(new VoltageControlMessage(value));
            }
        }

        public RelayCommand ResetCommand { get; private set; }
    }
}
