using System;
using GalaSoft.MvvmLight;

namespace Logic.TemperatureController.ViewModels
{
    public class SynchronizationViewModel : ViewModelBase//, IDataErrorInfo
    {
        
        #region Constructors
        public SynchronizationViewModel()
        {   
            //Errors = new Dictionary<string, string>();
        }
        #endregion


        #region Properties


        //[Range(0.0, 10.0, ErrorMessage = "Output voltage should be in the range 0-10V")]
        public double Vmin
        {
            get { return Settings.Vmin; }
            set
            {
                if (value > 10 || value < 0)                
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Vmin),
                        "Output voltage should be in the range 0-10V");
                    
                if (value > Settings.Vmax)
                    throw new ArithmeticException("The condition Vmin<Vmax is not fulfilled");

                Settings.Vmin = value;
            }
        }

        //[Range(0.0, 10.0, ErrorMessage = "Output voltage should be in the range 0-10V")]
        public double Vmax
        {
            get { return Settings.Vmax; }
            set
            {
                if (value > 10 || value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Vmax),
                        "Output voltage should be in the range 0-10V");

                if (value < Settings.Vmin)
                    throw new ArithmeticException("The condition Vmin<Vmax is not fulfilled");

                Settings.Vmax = value;
            }
        }

        //[Range(0.0, double.PositiveInfinity, ErrorMessage = "Temperature should be positive")]
        public double Tmin
        {
            get { return Settings.Tmin; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Tmin),
                        "Temperature should be positive");

                if (value > Settings.Tmax)
                    throw new ArithmeticException("The condition Tmin<Tmax is not fulfilled");

                Settings.Tmin = value;
            }
        }

        //[Range(0.0, double.PositiveInfinity, ErrorMessage = "Output voltage should be in the range 0-10V")]
        public double Tmax
        {
            get { return Settings.Tmax; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Tmin),
                        "Temperature should be positive");

                if (value < Settings.Tmin)
                    throw new ArithmeticException("The condition Tmin<Tmax is not fulfilled");

                Settings.Tmax = value;
            }
        }

        public double Rmin
        {
            get { return Settings.Rmin; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Rmin),
                        "Resistance should be positive");

                if (value > Settings.Rmax)
                    throw new ArithmeticException("The condition Tmin<Tmax is not fulfilled");

                Settings.Rmin = value;
            }
        }

        public double Rmax
        {
            get { return Settings.Rmax; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Settings.Rmin),
                        "Resistance should be positive");

                if (value < Settings.Rmin)
                    throw new ArithmeticException("The condition Rmin<Rmax is not fulfilled");

                Settings.Rmax = value;
            }
        }

        public bool IsTempRange
        {
            get { return Settings.IsTempRange; }
            set { Settings.IsTempRange = value; }
        }

        public bool IsResistanceRange
        {
            get { return Settings.IsResistanceRange; }
            set { Settings.IsResistanceRange = value; }
        }
        #endregion


        #region Using IDataErrorInfo

        //private Dictionary<string, string> Errors;
        //private static List<PropertyInfo> _propertyInfos;

        //protected List<PropertyInfo> PropertyInfos
        //{
        //    get
        //    {
        //        if (_propertyInfos == null)
        //        {
        //            _propertyInfos = GetType()
        //        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        //        .Where(prop => prop.IsDefined(typeof(RequiredAttribute), true) || prop.IsDefined(typeof(RangeAttribute), true))
        //        .ToList();
        //        }
        //        return _propertyInfos;
        //    }
        //}

        //public string Error => string.Empty;

        //public string this[string propertyName]
        //{
        //    get
        //    {
        //        CollectErrors();
        //        return Errors.ContainsKey(propertyName) ? Errors[propertyName] : string.Empty;
        //    }
        //}


        //private void CollectErrors()
        //{
        //    Errors.Clear();

        //    PropertyInfos.ForEach(
        //        prop =>
        //        {
        //            var currentValue = prop.GetValue(this);
        //            var requiredAttribute = prop.GetCustomAttribute<RequiredAttribute>();
        //            var rangeAttribute = prop.GetCustomAttribute<RangeAttribute>();
        //            if (requiredAttribute != null)
        //            {
        //                if (string.IsNullOrEmpty(currentValue?.ToString() ?? string.Empty))
        //                {
        //                    Errors.Add(prop.Name, requiredAttribute.ErrorMessage);
        //                }
        //            }

        //            if (rangeAttribute != null)
        //            {
        //                if (((double)currentValue > (double)rangeAttribute.Maximum
        //                || (double)currentValue < (double)rangeAttribute.Minimum))
        //                {
        //                    Errors.Add(prop.Name, rangeAttribute.ErrorMessage);
        //                }
        //            }
        //        });

        //    //OkCommand.RaiseCanExecuteChanged();
        //} 
        #endregion
    }
}
