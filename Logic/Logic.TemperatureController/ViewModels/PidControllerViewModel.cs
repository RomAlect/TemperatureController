using GalaSoft.MvvmLight;
using Logic.TemperatureController.Models;
using System;

namespace Logic.TemperatureController.ViewModels
{
    public class PidControllerViewModel : ViewModelBase
    {
        #region Fields
        
        #endregion

        #region Constructors
        public PidControllerViewModel()
        {
            
        }
        #endregion

        #region Properties

        public double Kp
        {
            get { return Settings.Kp; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Kp),
                        "Proportional gain should be positive");

                Settings.Kp = value;
            }
        }

        public double Ki
        {
            get { return Settings.Ki; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Ki),
                        "Integral gain should be positive");

                Settings.Ki = value;
            }
        }

        public double Kd
        {
            get { return Settings.Kd; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Kd),
                        "Differential gain should be positive");

                Settings.Kd = value;
            }
        }

        public double PIDScale
        {
            get { return Settings.PIDScale; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.PIDScale),
                        "PID scale should be positive");

                Settings.PIDScale = value;
            }
        }

        public double PIDVmin
        {
            get { return Settings.PIDVmin; }
            set
            {
                if (value > 10 || value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Vmin),
                        "Output voltage should be in the range 0-10V");

                if (value > Settings.PIDVmax)
                    throw new ArithmeticException("The condition Vmin<Vmax is not fulfilled");

                Settings.PIDVmin = value;
            }
        }

        public double PIDVmax
        {
            get { return Settings.PIDVmax; }
            set
            {
                if (value > 10 || value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.PIDVmax),
                        "Output voltage should be in the range 0-10V");

                if (value < Settings.PIDVmin)
                    throw new ArithmeticException("The condition Vmin<Vmax is not fulfilled");

                Settings.PIDVmax = value;
            }
        }


        #endregion
    }
}
