using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.TemperatureController.Models
{
    /// <summary>
    /// Defines an interface for temperature calculator
    /// </summary>
    public interface ITemperatureCalculator
    {
        double GetTemperature(double input);
    }
}
