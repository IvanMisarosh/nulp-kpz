using DbFirst.Models;
using DbFirst.Repositories;
using lab_3.ViewModels;
using System.Windows;
using Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Abstraction.ModelInterfaces;

//using CodeFirst.Models;
//using CodeFirst.Repositories;

namespace lab_3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<CarServiceKpzContext>();
            services.AddSingleton<IRepositoryFactory, DbFirstRepositoryFactory>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Register your ViewModels
            services.AddTransient<CarViewModel>();
            //services.AddTransient<CustomerViewModel>();
            //services.AddTransient<VisitViewModel>();
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow
            {
                DataContext = _serviceProvider.GetService<CarViewModel>()
            };
            mainWindow.Show();
        }
    }

}
