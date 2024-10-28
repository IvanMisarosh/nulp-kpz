using lab_3.Models;
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

namespace lab_3.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CarInfoControl: UserControl
    {
        public static readonly DependencyProperty CarProperty =
        DependencyProperty.Register(
            "Car",
            typeof(string),
            typeof(CarInfoControl),
            new PropertyMetadata(null));

        public Station Station
        {
            get => (Station)GetValue(CarProperty);
            set => SetValue(CarProperty, value);
        }

        public CarInfoControl()
        {
            InitializeComponent();
        }
    }
}
