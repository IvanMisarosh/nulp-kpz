using lab_3.Command;
using DbFirst.Models;
//using CodeFirst.Models;
using lab_3.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Abstraction;  


namespace lab_3.InfoWindows
{
    /// <summary>
    /// Interaction logic for VisitInfoWindow.xaml
    /// </summary>
    public partial class VisitInfoWindow : Window
    {
        public ObservableCollection<VisitStatus> VisitStatuses { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<PaymentStatus> PaymentStatuses { get; set; }
        public Visit SelectedVisit { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private IRepository<VisitStatus> _visitStatusRepository;
        private IRepository<Car> _carRepository;
        private IRepository<Employee> _employeeRepository;
        private IRepository<PaymentStatus> _paymentStatusRepository;
        private VisitViewModel _viewModel;

        public VisitInfoWindow()
        {
            InitializeComponent();
        }

        public VisitInfoWindow(
            IRepository<VisitStatus> visitStatusRepository,
            IRepository<Car> carRepository,
            IRepository<Employee> employeeRepository,
            IRepository<PaymentStatus> paymentStatusRepository,
            VisitViewModel viewModel)
        {
            InitializeComponent();
            _visitStatusRepository = visitStatusRepository;
            _carRepository = carRepository;
            _employeeRepository = employeeRepository;
            _paymentStatusRepository = paymentStatusRepository;
            _viewModel = viewModel;
            SelectedVisit = viewModel.SelectedVisit;

            VisitStatuses = new ObservableCollection<VisitStatus>(_visitStatusRepository.GetAll());
            Cars = new ObservableCollection<Car>(_carRepository.GetAll());
            Employees = new ObservableCollection<Employee>(_employeeRepository.GetAll());
            PaymentStatuses = new ObservableCollection<PaymentStatus>(_paymentStatusRepository.GetAll());

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
