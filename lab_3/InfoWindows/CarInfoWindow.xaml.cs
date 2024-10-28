using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using lab_3.Models;
using lab_3.Repositories;
using lab_3.ViewModels;
using lab_3.Command;

namespace lab_3.InfoWindows
{
    /// <summary>
    /// Interaction logic for CarInfoWindow.xaml
    /// </summary>
    public partial class CarInfoWindow : Window
    {
        public ObservableCollection<Models.Color> Colors { get; set; }
        public ObservableCollection<CarModel> CarModels { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public Car SelectedCar { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private ColorRepository _colorRepository;
        private CarModelRepository _carModelRepository;
        private CustomerRepository _customerRepository;
        private CarViewModel _viewModel;

        public CarInfoWindow()
        {
            InitializeComponent();
        }

        public CarInfoWindow(ColorRepository colorRepository, CarModelRepository carModelRepository, CustomerRepository customerRepository,  CarViewModel viewModel)
        {
            InitializeComponent();
            _colorRepository = colorRepository;
            _carModelRepository = carModelRepository;
            _customerRepository = customerRepository;
            _viewModel = viewModel;
            SelectedCar = viewModel.SelectedCar;

            Colors = new ObservableCollection<Models.Color>(_colorRepository.GetAll());
            CarModels = new ObservableCollection<CarModel>(_carModelRepository.GetAll());
            Customers = new ObservableCollection<Customer>(_customerRepository.GetAll());

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
