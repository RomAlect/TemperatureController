namespace Logic.TemperatureController.Messages
{
    public class TimerMessage
    {
        /// <summary>
        /// If true, TimersManager should swhich timer on. 
        /// If false, TimersManager should swhich timer off
        /// </summary>
        /// <param name="isTimerOn"></param>
        public TimerMessage(bool isTimerOn)
        {
            IsTimerOn = isTimerOn;
        }

        public bool IsTimerOn { get; private set; }
    }
}
