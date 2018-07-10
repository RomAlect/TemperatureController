using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.TemperatureController.Settings;
using static System.Math;

namespace Logic.TemperatureController.Models
{
    public class TemperatureCalculatorModel : ITemperatureCalculator
    {
        double ZU = Log10(3444.1380);
        double ZL = Log10(358.7981);
        double A0 = 13.019;
        double A1 = -14.3272;
        double A2 = 5.31008;
        double A3 = -1.3363;
        double A4 = 0.247;
        double A5 = -0.109409;
        double A6 = 0.00618477;
        double A7 = 0.0137707;
        double A8 = -0.0280874;
        double A9 = 0.0110468;

        double Z(double R)
        {
            return ((Log10(R) - ZL) - (ZU - Log10(R))) / (ZU - ZL);
        }

        double T(double x)
        {
            return A0 +
                A1 * Cos(Acos(x)) +
                A2 * Cos(2 * Acos(x)) +
                A3 * Cos(3 * Acos(x)) +
                A4 * Cos(4 * Acos(x)) +
                A5 * Cos(5 * Acos(x)) +
                A6 * Cos(6 * Acos(x)) +
                A7 * Cos(7 * Acos(x)) +
                A8 * Cos(8 * Acos(x)) +
                A9 * Cos(9 * Acos(x));
        }

        public double GetTemperature(double voltage)
        {
            double resistance;

            if (IsTempRange)
            {
                return Tmin + (Tmax - Tmin) * (voltage - Vmin) / (Vmax - Vmin);
            }
            else
            {
                resistance = Rmin + (Rmax - Rmin) * (voltage - Vmin) / (Vmax - Vmin);
                return T(Z(resistance));
            }


        }
    }
}
