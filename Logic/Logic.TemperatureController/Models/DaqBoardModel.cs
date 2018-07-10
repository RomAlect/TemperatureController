using NationalInstruments.DAQmx;
using System;
using System.Windows;

namespace Logic.TemperatureController.Models
{
    public class DaqBoardModel 
    {

        #region Constructors
        public DaqBoardModel()
        {
            Device = "dev1";
        }

        public DaqBoardModel(string device)
        {
            Device = device;
        }
        #endregion

        #region Properties
        public string Device { get; set; }
        #endregion

        #region Methods
        public double Read(string input)
        {
            try
            {
                Task analogInTask = new Task();
                AIChannel myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(
                    Device + "/" + input,
                    "myAIChannel",
                    AITerminalConfiguration.Rse,
                    Settings.Vmin,
                    Settings.Vmax,
                    AIVoltageUnits.Volts);
                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);
                double analogDataIn = reader.ReadSingleSample();
                return analogDataIn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public void Write(string output, double outputVoltage)
        {

            try
            {
                Task analogOutTask = new Task();
                AOChannel myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(
                Device + "/" + output,
                "myAOChannel",
                Settings.Vmin,
                Settings.Vmax,
                AOVoltageUnits.Volts
                );
                AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(analogOutTask.Stream);
                writer.WriteSingleSample(true, outputVoltage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        #endregion
    }
}
