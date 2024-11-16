using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using lab_3.InfoWindows;
using lab_3.Command;
using Abstraction;
using Abstraction.ModelInterfaces;

namespace lab_3.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ICar> Cars { get; set; }

        private ICar _selectedCar;
        private CarInfoWindow CarInfoWindow;
        public IRepositoryFactory RepositoryFactory { get; set; }
        public ICar SelectedCar
        {
            get => _selectedCar;
            set
            {
                if (_selectedCar != value)
                {
                    _selectedCar = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private readonly IRepository<ICar> _carRepository;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CarViewModel(IRepositoryFactory factory)
        {
            RepositoryFactory = factory;
            _carRepository = RepositoryFactory.GetRepository<ICar>();
            Cars = new ObservableCollection<ICar>(_carRepository.GetAll());

            AddCommand = new RelayCommand(AddCar);
            SaveCommand = new RelayCommand(SaveCar);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteCar);
            UpdateCommand = new RelayCommand(UpdateCar);
        }

        public void AddCar(object parameter)
        {
            SelectedCar = RepositoryFactory.CreateCar();
            OpenCarInfoWindow();
        }

        public void OpenCarInfoWindow()
        {
            if (CarInfoWindow != null)
            {
                CarInfoWindow.Close();
            }

            // Використовуємо інтерфейси для передачі в CarInfoWindow
            CarInfoWindow = new CarInfoWindow(
                RepositoryFactory.GetRepository<IColor>(),
                RepositoryFactory.GetRepository<ICarModel>(),
                RepositoryFactory.GetRepository<ICustomer>(),
                this);
            CarInfoWindow.Show();
        }


        public void SaveCar(object parameter)
        {
            if (SelectedCar == null) return;

            try
            {
                if (SelectedCar.CarID == 0)
                {
                    _carRepository.Add(SelectedCar);
                }
                else
                {
                    _carRepository.Update(SelectedCar);
                }
                _carRepository.SaveChanges();
                UpdateCarList();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Error saving car: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public void Cancel(object parameter)
        {
            CarInfoWindow?.Close();
        }

        private void DeleteCar(object parameter)
        {
            if (SelectedCar == null) return;

            try
            {
                _carRepository.Delete(SelectedCar);
                _carRepository.SaveChanges();
                UpdateCarList();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Error deleting car: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void UpdateCar(object parameter)
        {
            if (SelectedCar != null)
            {
                OpenCarInfoWindow();
            }
        }

        private void UpdateCarList()
        {
            Cars.Clear();
            var cars = _carRepository.GetAll();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }
    }
}
