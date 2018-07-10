using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Logic.TemperatureController.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                
            }
            else
            {
                // Create run time view services and models
                
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SynchronizationViewModel>();
            SimpleIoc.Default.Register<PidControllerViewModel>();
            SimpleIoc.Default.Register<TemperatureHistoryViewModel>();
            SimpleIoc.Default.Register<VoltageControlViewModel>();
            SimpleIoc.Default.Register<MWControllerViewModel>();
            SimpleIoc.Default.Register<COMSettingsViewModel>();
        }

        public MainViewModel MainVM => ServiceLocator.Current.GetInstance<MainViewModel>();
        public SynchronizationViewModel SyncVM => ServiceLocator.Current.GetInstance<SynchronizationViewModel>();
        public PidControllerViewModel PidVM => ServiceLocator.Current.GetInstance<PidControllerViewModel>();
        public TemperatureHistoryViewModel TemperatureVM => ServiceLocator.Current.GetInstance<TemperatureHistoryViewModel>();
        public VoltageControlViewModel VoltageControlVM => ServiceLocator.Current.GetInstance<VoltageControlViewModel>();
        public MWControllerViewModel MWVM => ServiceLocator.Current.GetInstance<MWControllerViewModel>();
        public COMSettingsViewModel COMVM => ServiceLocator.Current.GetInstance<COMSettingsViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}