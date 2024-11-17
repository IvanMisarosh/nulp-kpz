using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Abstraction;
using Abstraction.ModelInterfaces;
using lab_3.Command;
using lab_3.InfoWindows;
using Newtonsoft.Json;
using Abstraction.DTOs;

namespace lab_3.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private readonly IRepository<ICustomer> _customerRepository;
        private ICustomer _selectedCustomer;
        private CustomerInfoWindow _customerInfoWindow;

        private ObservableCollection<ICustomer> _customers;
        public ObservableCollection<ICustomer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }
        public IRepositoryFactory RepositoryFactory { get; }

        public ICustomer SelectedCustomer
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
            RepositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
            _customerRepository = repositoryFactory.GetRepository<ICustomer>();

            // Initialize commands
            AddCommand = new RelayCommand(AddCustomer);
            SaveCommand = new RelayCommand(SaveCustomer);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer);

            // Load initial data
            InitializeCustomers();
        }

        private async void InitializeCustomers()
        {
            var response = await HttpClient.GetStringAsync($"{ServiceUrl}api/Customer");
            var customers = JsonConvert.DeserializeObject<List<CustomerDTO>>(response);
            if (customers is null)
                return;
            Customers = new ObservableCollection<ICustomer>(customers);

        }

        public void AddCustomer(object parameter)
        {
            SelectedCustomer = RepositoryFactory.CreateCustomer();
            OpenCustomerInfoWindow();
        }

        public void SaveCustomer(object parameter)
        {
            if (SelectedCustomer == null) return;

            try
            {
                if (SelectedCustomer.CustomerID == 0)
                {
                    _customerRepository.Add(SelectedCustomer);
                }
                else
                {
                    _customerRepository.Update(SelectedCustomer);
                }
                _customerRepository.SaveChanges();
                UpdateCustomerList();
                _customerInfoWindow?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                try
                {
                    _customerRepository.Delete(SelectedCustomer);
                    _customerRepository.SaveChanges();
                    UpdateCustomerList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
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

        private void UpdateCustomerList()
        {
            if (Customers == null)
            {
                Customers = new ObservableCollection<ICustomer>();
            }

            try
            {
                Customers.Clear();
                var customers = _customerRepository.GetAll();
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
                System.Diagnostics.Debug.WriteLine($"Updated customer list: {Customers.Count} customers");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer list: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}