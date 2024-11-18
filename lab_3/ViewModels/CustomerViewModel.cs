using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Abstraction;
using lab_3.Command;
using lab_3.InfoWindows;
using Newtonsoft.Json;
using System.Net.Http;
using Abstraction.DTOs;
using System.Text;

namespace lab_3.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private CustomerDTO _selectedCustomer;
        private CustomerInfoWindow _customerInfoWindow;

        private ObservableCollection<CustomerDTO> _customers;
        public ObservableCollection<CustomerDTO> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        public CustomerDTO SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        // Commands
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public CustomerViewModel(IRepositoryFactory repositoryFactory)
        {

            // Initialize commands
            AddCommand = new RelayCommand(AddCustomer);
            SaveCommand = new RelayCommand(SaveCustomer);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer);

            // Load initial data
            LoadCustomers();
        }

        private async void LoadCustomers()
        {
            var response = await HttpClient.GetStringAsync($"{ServiceUrl}api/Customer");
            var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(response);
            if (customers is null)
                return;
            Customers = new ObservableCollection<CustomerDTO>(customers);

        }

        public void AddCustomer(object parameter)
        {
            SelectedCustomer = new CustomerDTO();
            OpenCustomerInfoWindow();
        }

        public async void SaveCustomer(object parameter)
        {
            if (SelectedCustomer == null) return;

            var json = JsonConvert.SerializeObject(SelectedCustomer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            
            if (SelectedCustomer.CustomerID == 0)
            {
                var response = await HttpClient.PostAsync($"{ServiceUrl}api/Customer", content);
            }
            else
            {
                var response = await HttpClient.PutAsync($"{ServiceUrl}api/Customer/{SelectedCustomer.CustomerID}", content);
            }
            LoadCustomers();
            _customerInfoWindow?.Close();
            
        }

        private void OpenCustomerInfoWindow()
        {
            if (_customerInfoWindow != null)
            {
                _customerInfoWindow.Close();
            }

            _customerInfoWindow = new CustomerInfoWindow
            {
                DataContext = this
            };
            _customerInfoWindow.Show();
        }

        private void DeleteCustomer(object parameter)
        {
            if (SelectedCustomer == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this customer?",
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (result == MessageBoxResult.Yes)
            {
                var customerId = SelectedCustomer.CustomerID;
                var response = HttpClient.DeleteAsync($"{ServiceUrl}api/Customer/{customerId}");
                LoadCustomers();
            }
        }

        private void UpdateCustomer(object parameter)
        {
            if (SelectedCustomer != null)
            {
                OpenCustomerInfoWindow();
            }
        }

        private void Cancel(object parameter)
        {
            _customerInfoWindow?.Close();
        }

    }
}