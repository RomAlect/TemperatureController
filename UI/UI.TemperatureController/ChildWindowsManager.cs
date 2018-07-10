using GalaSoft.MvvmLight.Messaging;
using Logic.TemperatureController.Messages;
using System.IO;
using System.Windows;
using UI.TemperatureController.Views;

namespace UI.TemperatureController
{
    public class ChildWindowsManager
    {
        public ChildWindowsManager()
        {
            Messenger.Default.Register<COMSettingsMessage>(
               this,
               msg =>
               {
                   if (msg.IsShow)
                   {
                       var comWindow = new COMSettingsView();
                       comWindow.ShowDialog();
                   }

               });

            Messenger.Default.Register<HelpMessage>(
               this,
               msg =>
               {
                   if (msg.IsShow)
                   {
                       var helpWindow = new HelpView();
                       helpWindow.Show();
                   }

               });
        }

        /// <summary>
        /// We need this property to create an instance of TimersManager through binding to this property from MainWindow.
        /// </summary>
        public Visibility BindableProperty => Visibility.Visible;
    }
}
