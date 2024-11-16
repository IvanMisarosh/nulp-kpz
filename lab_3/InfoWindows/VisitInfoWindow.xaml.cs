using lab_3.Command;
//using DbFirst.Models;
//using CodeFirst.Models;
using lab_3.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Abstraction;  
using Abstraction.ModelInterfaces;


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

        private IRepository<IVisitStatus> _visitStatusRepository;
        private IRepository<ICar> _carRepository;
        private IRepository<IEmployee> _employeeRepository;
        private IRepository<IPaymentStatus> _paymentStatusRepository;
        private VisitViewModel _viewModel;

        public VisitInfoWindow()
        {
            InitializeComponent();
        }

        public VisitInfoWindow(
            IRepository<IVisitStatus> visitStatusRepository,
            IRepository<ICar> carRepository,
            IRepository<IEmployee> employeeRepository,
            IRepository<IPaymentStatus> paymentStatusRepository,
            VisitViewModel viewModel)
        {
            InitializeComponent();
            _visitStatusRepository = visitStatusRepository;
            _carRepository = carRepository;
            _employeeRepository = employeeRepository;
            _paymentStatusRepository = paymentStatusRepository;
            _viewModel = viewModel;
            SelectedVisit = viewModel.SelectedVisit;

            VisitStatuses = new ObservableCollection<IVisitStatus>(_visitStatusRepository.GetAll());
            Cars = new ObservableCollection<ICar>(_carRepository.GetAll());
            Employees = new ObservableCollection<IEmployee>(_employeeRepository.GetAll());
            PaymentStatuses = new ObservableCollection<IPaymentStatus>(_paymentStatusRepository.GetAll());

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
