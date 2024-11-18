using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Abstraction;
using Abstraction.ModelInterfaces;
using lab_3.Command;
using lab_3.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using Abstraction.DTOs;
using System.Text;


namespace lab_3.InfoWindows
{
    /// <summary>
    /// Interaction logic for CarInfoWindow.xaml
    /// </summary>
    public partial class CarInfoWindow : Window
    {
        public ObservableCollection<IColor> Colors { get; set; }
        public ObservableCollection<ICarModel> CarModels { get; set; }
        public ObservableCollection<ICustomer> Customers { get; set; }
        public ICar SelectedCar { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private readonly CarViewModel _viewModel;

        public CarInfoWindow()
        {
            InitializeComponent();
        }

        // Оновлений конструктор з використанням інтерфейсів
        public CarInfoWindow(CarViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;

            // Ініціалізація даних
            SelectedCar = viewModel.SelectedCar;
            var ServiceUrl = BaseViewModel.ServiceUrl;
            var response = viewModel.HttpClient.GetAsync($"{ServiceUrl}api/Color");
            if (response.Result.IsSuccessStatusCode)
            {
                var content = response.Result.Content.ReadAsStringAsync();
                var colors = JsonConvert.DeserializeObject<List<ColorDTO>>(content.Result);
                Colors = new ObservableCollection<IColor>(colors);
            }

            response = viewModel.HttpClient.GetAsync($"{ServiceUrl}api/CarModel");
            if (response.Result.IsSuccessStatusCode)
            {
                var content = response.Result.Content.ReadAsStringAsync();
                var carModels = JsonConvert.DeserializeObject<List<CarModelDTO>>(content.Result);
                CarModels = new ObservableCollection<ICarModel>(carModels);
            }

            response = viewModel.HttpClient.GetAsync($"{ServiceUrl}api/Customer");
            if (response.Result.IsSuccessStatusCode)
            {
                var content = response.Result.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(content.Result);
                Customers = new ObservableCollection<ICustomer>(customers);
            }


            // Налаштування команд
            SaveCommand = new RelayCommand(o =>
            {
                _viewModel.SaveCar(SelectedCar);
                this.Close();
            });

            CancelCommand = new RelayCommand(o =>
            {
                _viewModel.Cancel(SelectedCar);
                this.Close();
            });

            DataContext = this;
        }
    }
}
