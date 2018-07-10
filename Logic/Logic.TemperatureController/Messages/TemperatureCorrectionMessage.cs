namespace Logic.TemperatureController.Messages
{
    public class TemperatureCorrectionMessage
    {        
        public TemperatureCorrectionMessage(MWCommand command)
        {
            CorrectionCommand = command;
        }

        public MWCommand CorrectionCommand { get; private set; }
    }
}
