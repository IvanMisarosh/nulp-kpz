using lab_3.ViewModels;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using lab_3;



namespace lab_3
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        //private IConfiguration _configuration;

        public App()
        {
            var services = new ServiceCollection();

            // Register your ViewModels
            services.AddTransient<CarViewModel>();
            services.AddTransient<CustomerViewModel>();
            services.AddTransient<VisitViewModel>();

            // Register MainViewModel
            services.AddTransient<MainViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow
            {
                DataContext = _serviceProvider.GetService<MainViewModel>()
            };
            mainWindow.Show();
        }
    }
}
