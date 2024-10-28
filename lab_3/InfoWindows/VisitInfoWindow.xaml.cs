using lab_3.Command;
using lab_3.Models;
using lab_3.Repositories;
using lab_3.ViewModels;
using System;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
//using lab_3.Models;
//using lab_3.Repositories;
//using lab_3.ViewModels;
//using lab_3.Command;

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

        private VisitStatusRepository _visitStatusRepository;
        private CarRepository _carRepository;
        private EmployeeRepository _employeeRepository;
        private PaymentStatusRepository _paymentStatusRepository;
        private VisitViewModel _viewModel;

        public VisitInfoWindow()
        {
            InitializeComponent();
        }

        public VisitInfoWindow(
            VisitStatusRepository visitStatusRepository,
            CarRepository carRepository,
            EmployeeRepository employeeRepository,
            PaymentStatusRepository paymentStatusRepository,
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
