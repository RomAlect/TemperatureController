using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.TemperatureController.Views
{
    /// <summary>
    /// Interaction logic for VoltageControlView.xaml
    /// </summary>
    public partial class VoltageControlView : UserControl
    {
        public VoltageControlView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PanelTitleProperty =
            DependencyProperty.Register(
            "PanelTitle",
            typeof(string),
            typeof(VoltageControlView),
            new UIPropertyMetadata("Panel Title"));

        public string PanelTitle
        {
            get { return (string)GetValue(PanelTitleProperty); }
            set { SetValue(PanelTitleProperty, value); }
        }
    }
}
