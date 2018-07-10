namespace Logic.TemperatureController.Messages
{
    public class TTLTimerMessage : TimerMessage
    {
        public TTLTimerMessage(bool isTimerOn) : base(isTimerOn) { }
    }
}
