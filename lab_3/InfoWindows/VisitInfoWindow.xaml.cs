using lab_3.Command;
using lab_3.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Abstraction.ModelInterfaces;
using Abstraction.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace lab_3.InfoWindows
{
    /// <summary>
    /// Interaction logic for VisitInfoWindow.xaml
    /// </summary>
    public partial class VisitInfoWindow : Window
    {
        public ObservableCollection<IVisitStatus> VisitStatuses { get; set; }
        public ObservableCollection<ICar> Cars { get; set; }
        public ObservableCollection<IEmployee> Employees { get; set; }
        public ObservableCollection<IPaymentStatus> PaymentStatuses { get; set; }
        public IVisit SelectedVisit { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private VisitViewModel _viewModel;

        public VisitInfoWindow()
        {
            InitializeComponent();
        }

        public VisitInfoWindow(VisitViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            SelectedVisit = viewModel.SelectedVisit;

            var BaseUrl = BaseViewModel.ServiceUrl;
            var response = viewModel.HttpClient.GetAsync($"{BaseUrl}api/VisitStatus");
            if (response.Result.IsSuccessStatusCode)
            {
                var content = response.Result.Content.ReadAsStringAsync();
                var visitStatuses = JsonConvert.DeserializeObject<List<VisitStatusDTO>>(content.Result);
                VisitStatuses = new ObservableCollection<IVisitStatus>(visitStatuses);
            }

            response = viewModel.HttpClient.GetAsync($"{BaseUrl}api/Car");
            if (response.Result.IsSuccessStatusCode)
            {
                var content = response.Result.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<CarDTO>>(content.Result);
                Cars = new ObservableCollection<ICar>(cars);
            }

            response = viewModel.HttpClient.GetAsync($"{BaseUrl}api/Employee");
            if (response.Result.IsSuccessStatusCode)
            {
                var content = response.Result.Content.ReadAsStringAsync();
                var employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(content.Result);
                Employees = new ObservableCollection<IEmployee>(employees);
            }

            response = viewModel.HttpClient.GetAsync($"{BaseUrl}api/PaymentStatus");
            if (response.Result.IsSuccessStatusCode)
            {
                var content = response.Result.Content.ReadAsStringAsync();
                var paymentStatuses = JsonConvert.DeserializeObject<List<PaymentStatusDTO>>(content.Result);
                PaymentStatuses = new ObservableCollection<IPaymentStatus>(paymentStatuses);
            }

            //VisitStatuses = new ObservableCollection<IVisitStatus>(_visitStatusRepository.GetAll());
            //Cars = new ObservableCollection<ICar>(_carRepository.GetAll());
            //Employees = new ObservableCollection<IEmployee>(_employeeRepository.GetAll());
            //PaymentStatuses = new ObservableCollection<IPaymentStatus>(_paymentStatusRepository.GetAll());

            SaveCommand = new RelayCommand(o =>
            {
                _viewModel.SaveVisit(SelectedVisit);
                this.Close();
            });

            CancelCommand = new RelayCommand(o =>
            {
                _viewModel.Cancel(SelectedVisit);
                this.Close();
            });

            DataContext = this;
        }
    }
}
