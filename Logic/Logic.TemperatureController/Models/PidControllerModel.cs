using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.TemperatureController.Models
{
    public class PidControllerModel
    {
        #region Fields
        private double error;
        private double prev_error;
        private double prevprev_error;
        //private double outputVoltage;
        #endregion       

        #region Methods
        public double CalculateOutputVoltage(double currentTemperature)
        {
            //outputVoltage = Settings.OutputVoltage;
            error = Settings.DesiredTemperature - currentTemperature;
            Settings.OutputVoltage = Settings.OutputVoltage + Settings.PIDScale *
                (
                Settings.Kp * (error - prev_error) +
                Settings.Ki * error + Settings.Kd * (error - 2 * prev_error + prevprev_error)
                );
            prevprev_error = prev_error;
            prev_error = error;

            if (Settings.OutputVoltage <= Settings.PIDVmin)
                Settings.OutputVoltage = Settings.PIDVmin;
            if (Settings.OutputVoltage >= Settings.PIDVmax)
                Settings.OutputVoltage = Settings.PIDVmax;

            return Settings.OutputVoltage;

        } 
        #endregion

       

    }
}
