using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.TemperatureController.Messages
{
    public class MWSourceMessage
    {
        public MWSourceMessage(string mwMode, bool isTemperatureCorrection, MWCommand command)
        {
            MWMode = mwMode;
            IsTemperatureCorrection = isTemperatureCorrection;
            MWCommand = command;
        }

        public string MWMode { get; private set; }
        public bool IsTemperatureCorrection { get; private set; }
        public MWCommand MWCommand { get; private set; }
    }
}
