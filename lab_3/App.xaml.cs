using lab_3.ViewModels;
using System.Windows;

namespace lab_3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public CarViewModel CarViewModel { get; set; }
        public CustomerViewModel CustomerViewModel { get; set; }
        public VisitViewModel VisitViewModel { get; set; }

        public App()
        {
            CarViewModel = new CarViewModel();
            CustomerViewModel = new CustomerViewModel();
            VisitViewModel = new VisitViewModel();
            var mainWindow = new MainWindow
            {
                DataContext = this
            };
            mainWindow.Show();

        }
    }

}
