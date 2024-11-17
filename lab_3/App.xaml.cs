using DbFirst.Models;
using DbFirst.Repositories;

using lab_3.ViewModels;
using System.Windows;
using Abstraction;
using Microsoft.Extensions.DependencyInjection;

//using CodeFirst.Models;
//using CodeFirst.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;


namespace lab_3
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        //private IConfiguration _configuration;

        public App()
        {
            var services = new ServiceCollection();
            //_configuration = new ConfigurationBuilder()
            //  .SetBasePath("C:\\Users\\Ivan\\Desktop\\Навчання\\5th sem\\КПЗ\\lab_3\\lab_3")  // Set the base path to the directory of the app
            //  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //  .Build();

            //services.AddDbContext<CarServiceKpzContext>(options =>
            //    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            //);

            // Register your services
            services.AddSingleton<CarServiceKpzContext>();
            services.AddSingleton<IRepositoryFactory, DbFirstRepositoryFactory>();
            //services.AddSingleton<IRepositoryFactory, CodeFirstRepositoryFactory>();

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
