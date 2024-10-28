using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using lab_3.Models;
using lab_3.Repositories;
using lab_3.InfoWindows;
using lab_3.Command;
using System.Windows;

namespace lab_3.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set; }

        private Customer _selectedCustomer;
        private CustomerInfoWindow _customerInfoWindow;

        public Customer SelectedCustomer
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

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private readonly CustomerRepository _customerRepository;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CustomerViewModel()
        {
            _customerRepository = new CustomerRepository(new CarServiceKpzContext());
            Customers = new ObservableCollection<Customer>(_customerRepository.GetAll());

            AddCommand = new RelayCommand(AddCustomer);
            SaveCommand = new RelayCommand(SaveCustomer);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteCustomer);
            UpdateCommand = new RelayCommand(UpdateCustomer);

        }

        public void AddCustomer(object parameter)
        {
            SelectedCustomer = new Customer();
            OpenCustomerInfoWindow();
        }

        public void SaveCustomer(object parameter)
        {
            try
            {
                if (SelectedCustomer.CustomerId == 0)
                {
                    _customerRepository.Add(SelectedCustomer);
                    //Customers.Add(SelectedCustomer);
                }
                else
                {
                    _customerRepository.Update(SelectedCustomer);
                }
                _customerRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the visit: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateCustomerList();

            _customerInfoWindow.Close();
        }

        public void OpenCustomerInfoWindow()
        {
            _customerInfoWindow = new CustomerInfoWindow
            {
                DataContext = this
            };
            _customerInfoWindow.Show();
        }

        private void DeleteCustomer(object parameter)
        {
            if (SelectedCustomer == null)
            {
                return;
            }
            try
            {
                _customerRepository.Delete(SelectedCustomer);
                _customerRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the customer: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateCustomerList();
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
            _customerInfoWindow.Close();
        }

        private void UpdateCustomerList()
        {
            if (Customers == null)
            {
                Customers = new ObservableCollection<Customer>();
            }
            Customers.Clear();
            try
            {
                var customers = _customerRepository.GetAll();
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the customer list: {ex.Message}", "Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
