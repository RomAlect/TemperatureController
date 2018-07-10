namespace Logic.TemperatureController.Messages
{
    /// <summary>
    /// Wrapper for messages sended to temperature timer
    /// </summary>
    public class TemperatureTimerMessage : TimerMessage
    {
        public TemperatureTimerMessage(bool isTimerOn):base(isTimerOn) { }
    }
}
