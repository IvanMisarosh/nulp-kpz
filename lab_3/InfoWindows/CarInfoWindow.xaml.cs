using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Abstraction;
using Abstraction.ModelInterfaces;
using lab_3.Command;
using lab_3.ViewModels;

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

        private readonly IRepository<IColor> _colorRepository;
        private readonly IRepository<ICarModel> _carModelRepository;
        private readonly IRepository<ICustomer> _customerRepository;
        private readonly CarViewModel _viewModel;

        public CarInfoWindow()
        {
            InitializeComponent();
        }

        // Оновлений конструктор з використанням інтерфейсів
        public CarInfoWindow(
            IRepository<IColor> colorRepository,
            IRepository<ICarModel> carModelRepository,
            IRepository<ICustomer> customerRepository,
            CarViewModel viewModel)
        {
            InitializeComponent();

            _colorRepository = colorRepository;
            _carModelRepository = carModelRepository;
            _customerRepository = customerRepository;
            _viewModel = viewModel;

            // Ініціалізація даних
            SelectedCar = viewModel.SelectedCar;
            Colors = new ObservableCollection<IColor>(_colorRepository.GetAll());
            CarModels = new ObservableCollection<ICarModel>(_carModelRepository.GetAll());
            Customers = new ObservableCollection<ICustomer>(_customerRepository.GetAll());

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
