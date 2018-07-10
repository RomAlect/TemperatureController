using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.TemperatureController.Messages
{
    public class COMSettingsMessage
    {
        /// <summary>
        /// If true, COMSettingView window should be opened. 
        /// If false, COMSettingView window should be closed, if it's opened, otherwise nothing should be done
        /// </summary>
        /// <param name="isTimerOn"></param>
        public COMSettingsMessage(bool isShow)
        {
            IsShow = isShow;
        }

        public bool IsShow { get; private set; }
    }
}
