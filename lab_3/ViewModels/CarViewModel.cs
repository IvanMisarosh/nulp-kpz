using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using lab_3.Models;
using lab_3.Repositories;
using lab_3.InfoWindows;
using lab_3.Command;

namespace lab_3.ViewModels
{

    public class CarViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; set; }

        private Car _selectedCar;
        private CarInfoWindow CarInfoWindow;
        public Car SelectedCar
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

        private readonly CarRepository _carRepository;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CarViewModel()
        {
            _carRepository = new CarRepository(new CarServiceKpzContext());
            Cars = new ObservableCollection<Car>(_carRepository.GetAll());

            AddCommand = new RelayCommand(AddCar);
            SaveCommand = new RelayCommand(SaveCar);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteCar);
            UpdateCommand = new RelayCommand(UpdateCar);
        }

        public void AddCar(object parameter)
        {
            SelectedCar = new Car();
            OpenCarInfoWindow();
        }

        public void OpenCarInfoWindow()
        {
            if (CarInfoWindow != null)
            {
                CarInfoWindow.Close();
            }

            CarInfoWindow = new CarInfoWindow(new ColorRepository(new CarServiceKpzContext()),
                new CarModelRepository(new CarServiceKpzContext()),
                new CustomerRepository(new CarServiceKpzContext()),
                this);
            CarInfoWindow.Show();

        }

        public void SaveCar(object parameter)
        {
            if (SelectedCar != null)
            {
                if (SelectedCar.CarId == 0)
                {
                    _carRepository.Add(SelectedCar);
                    //Cars.Add(SelectedCar);
                    UpdateCarList();
                }
                else
                {
                    _carRepository.Update(SelectedCar);
                    UpdateCarList();
                }

            }
        }

        public void Cancel(object parameter)
        {
            if (CarInfoWindow != null)
            {
                CarInfoWindow.Close();
            }
        }

        private void DeleteCar(object parameter)
        {
            if (SelectedCar != null)
            {
                _carRepository.Delete(SelectedCar);
                //Cars.Remove(SelectedCar);
            }
            UpdateCarList();
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
