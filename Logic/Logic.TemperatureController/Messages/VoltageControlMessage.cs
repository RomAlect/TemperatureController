namespace Logic.TemperatureController.Messages
{
    public class VoltageControlMessage
    {        
        public VoltageControlMessage(double manualVoltage)
        {
            ManualOutputVoltage = manualVoltage;
        }

        public double ManualOutputVoltage { get; private set; }
    }
}
