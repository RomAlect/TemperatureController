using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI.TemperatureController.Views
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : Window
    {
        public HelpView()
        {   
            var webBrowser = new WebBrowser();
            webBrowser.Source = new Uri(Directory.GetCurrentDirectory() + @"\Help.pdf");
            AddChild(webBrowser);
            InitializeComponent();
        }

        
    }
}
