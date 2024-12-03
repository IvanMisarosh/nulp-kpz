using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Abstraction;
using lab_3.Command;
using lab_3.InfoWindows;
using Newtonsoft.Json;
using System.Net.Http;
//using Abstraction.DTOs;
using System.Text;
using Wpf.Models;


namespace lab_3.ViewModels
{
    public class CarViewModel : BaseViewModel
    {
        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    OnPropertyChanged();
                }
            }
        }


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


        public CarViewModel()
        {
            LoadCars();

            AddCommand = new RelayCommand(AddCar);
            SaveCommand = new RelayCommand(SaveCar);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteCar);
            UpdateCommand = new RelayCommand(UpdateCar);
        }

        private async void LoadCars()
        {
            var response = await HttpClient.GetStringAsync($"{ServiceUrl}api/Car");
            var cars = JsonConvert.DeserializeObject<List<Car>>(response);
            if (cars is null)
                return;
            Cars = new ObservableCollection<Car>(cars);

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

            // Використовуємо інтерфейси для передачі в CarInfoWindow
            CarInfoWindow = new CarInfoWindow(this);
            CarInfoWindow.Show();
        }


        public async void SaveCar(object parameter)
        {
            if (SelectedCar == null) return;

            var json = JsonConvert.SerializeObject(SelectedCar);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (SelectedCar.CarID == 0)
            {
                var response = await HttpClient.PostAsync($"{ServiceUrl}api/Car", content);
            }
            else
            {
                var response = await HttpClient.PutAsync($"{ServiceUrl}api/Car/{SelectedCar.CarID}", content);
            }

            LoadCars();
        }

        public void Cancel(object parameter)
        {
            CarInfoWindow?.Close();
        }

        private async void DeleteCar(object parameter)
        {
            if (SelectedCar == null) return;

            var result = System.Windows.MessageBox.Show("Are you sure you want to delete this car?",
                "Confirm Delete", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);

            if (result == System.Windows.MessageBoxResult.Yes)
            {
                var carId = SelectedCar.CarID;
                var response = await HttpClient.DeleteAsync($"{ServiceUrl}api/Car/{carId}");
                LoadCars();
            }

        }

        private void UpdateCar(object parameter)
        {
            if (SelectedCar != null)
            {
                OpenCarInfoWindow();
            }
        }
    }
}
