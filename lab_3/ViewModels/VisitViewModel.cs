using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using lab_3.InfoWindows;
using lab_3.Command;
using System.Windows;
using Abstraction;
using Abstraction.ModelInterfaces;

namespace lab_3.ViewModels
{
    public class VisitViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<IVisit> Visits { get; set; }

        private IVisit _selectedVisit;
        private IVisit _editableVisit;
        private VisitInfoWindow _visitInfoWindow;
        public IRepositoryFactory RepositoryFactory { get; set; }

        public IVisit SelectedVisit
        {
            get => _selectedVisit;
            set
            {
                if (_selectedVisit != value)
                {
                    _selectedVisit = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private readonly IRepository<IVisit> _visitRepository;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public VisitViewModel(IRepositoryFactory factory)
        {
            RepositoryFactory = factory;
            //Context = context;
            _visitRepository = factory.GetRepository<IVisit>();
            UpdateVisitList();

            AddCommand = new RelayCommand(AddVisit);
            SaveCommand = new RelayCommand(SaveVisit);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteVisit);
            UpdateCommand = new RelayCommand(UpdateVisit);
            
        }

        public void AddVisit(object parameter)
        {
            SelectedVisit = RepositoryFactory.CreateVisit();
            OpenVisitInfoWindow();
        }

        public void OpenVisitInfoWindow()
        {
            if (_visitInfoWindow != null)
            {
                _visitInfoWindow.Close();
            }

            _visitInfoWindow = new VisitInfoWindow(
                RepositoryFactory.GetRepository<IVisitStatus>(),
                RepositoryFactory.GetRepository<ICar>(),
                RepositoryFactory.GetRepository<IEmployee>(),
                RepositoryFactory.GetRepository<IPaymentStatus>(),
                this);
            _visitInfoWindow.Show();
        }

        public void SaveVisit(object parameter)
        {
            if (SelectedVisit == null)
            {
                return;
            }
            try
            { 
                if (SelectedVisit.VisitID == 0)
                {
                    GenerateRandomVisitNumber();
                    _visitRepository.Add(SelectedVisit);
                }
                else
                {
                    _visitRepository.Update(SelectedVisit);
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the visit: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _visitRepository.SaveChanges();
            UpdateVisitList();
        }

        private void GenerateRandomVisitNumber()
        {
            var random = new Random();
            SelectedVisit.VisitNumber = random.Next(1000, 99999);
        }

        public void Cancel(object parameter)
        {
            if (_visitInfoWindow != null)
            {
                _visitInfoWindow.Close();
            }
        }

        private void DeleteVisit(object parameter)
        {
            if (SelectedVisit != null)
            {
                try
                {
                    _visitRepository.Delete(SelectedVisit);
                    _visitRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the visit: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            UpdateVisitList();
        }

        private void UpdateVisit(object parameter)
        {
            if (SelectedVisit != null)
            {
                OpenVisitInfoWindow();
            }
        }

        private void UpdateVisitList()
        {
            if (Visits == null)
            {
                Visits = new ObservableCollection<IVisit>();
            }

            Visits.Clear();
            try
            {
                var visits = _visitRepository.GetAll();
                foreach (var visit in visits)
                {
                    Visits.Add(visit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the visit list: {ex.Message}", "Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
