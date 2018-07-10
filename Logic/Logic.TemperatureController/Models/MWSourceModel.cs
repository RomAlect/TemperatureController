using System;
using System.IO.Ports;
using System.Threading;

namespace Logic.TemperatureController.Models
{
    public class MWSourceModel
    {
        #region Constructors
        public MWSourceModel(SerialPort port)
        {
            SerialPort = port;
        }
        #endregion

        #region Properties
        public SerialPort SerialPort { get; set; }
        #endregion

        public void SendMWCommand(MWCommand command)
        {
            int i = 0;
            string stateString = String.Empty;
            bool isDelivered = false;
            do
            {
                i++;
                SerialPort.Open();
                switch (command)
                {
                    case MWCommand.SetPower:
                        SerialPort.Write("@PWR!" + Settings.MWPower.ToString("000") + "#");
                        break;
                    case MWCommand.SetFrequency:
                        SerialPort.Write("@FRQ!" + Settings.MWFrequency.ToString("0.00") + "#");
                        break;
                    case MWCommand.On:
                        SerialPort.Write("@U27!on#");
                        break;
                    case MWCommand.Off:
                        SerialPort.Write("@U27!off#");
                        break;
                }

                Thread.Sleep(10);
                stateString = SerialPort.ReadExisting();
                SerialPort.Close();

                if (stateString != String.Empty)
                    if (stateString.Substring(0, 1) == "@")
                        isDelivered = true;
            }
            while (!isDelivered && i < 10);

            if (i == 10)
                throw new Exception("MW source does not respond to commands");
        }
        /// <summary>
        /// Returns true if MW source is switched on; otherwise false
        /// </summary>
        /// <returns></returns>
        public bool IsMwOn()
        {
            int i = 0;
            string stateString = String.Empty;
            bool isDelivered = false;
            do
            {
                i++;
                SerialPort.Open();
                SerialPort.Write("@U27?#");
                Thread.Sleep(10);
                stateString = SerialPort.ReadExisting();
                SerialPort.Close();

                if (stateString != String.Empty)
                    if (stateString.Substring(0, 1) == "@")
                        isDelivered = true;
            }
            while (!isDelivered && i < 10);

            if (i == 10)
                throw new Exception("MW source does not respond to commands");

            if (stateString.Substring(stateString.Length - 3) == "on#")
                return true;
            else
                return false;

        }


    }
}
