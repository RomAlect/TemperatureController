using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.TemperatureController.Messages
{
    public class HelpMessage
    {
        /// <summary>
        /// If true, HelpView window should be opened. 
        /// If false, HelpView window should be closed, if it's opened, otherwise nothing should be done
        /// </summary>
        public HelpMessage(bool isShow)
        {
            IsShow = isShow;
        }

        public bool IsShow { get; private set; }
    }
}
