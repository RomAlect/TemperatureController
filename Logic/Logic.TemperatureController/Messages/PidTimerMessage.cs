using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.TemperatureController.Messages
{
    /// <summary>
    /// Wrapper for messages sended to PID timer
    /// </summary>
    public class PidTimerMessage : TimerMessage
    {
        public PidTimerMessage(bool isTimerOn) : base(isTimerOn) { }
    }
}
