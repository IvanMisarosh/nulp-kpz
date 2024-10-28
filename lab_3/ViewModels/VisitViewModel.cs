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
    public class VisitViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Visit> Visits { get; set; }

        private Visit _selectedVisit;
        private VisitInfoWindow _visitInfoWindow;

        public Visit SelectedVisit
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

        private readonly VisitRepository _visitRepository;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public VisitViewModel()
        {
            _visitRepository = new VisitRepository(new CarServiceKpzContext());
            Visits = new ObservableCollection<Visit>(_visitRepository.GetAll());

            AddCommand = new RelayCommand(AddVisit);
            SaveCommand = new RelayCommand(SaveVisit);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteVisit);
            UpdateCommand = new RelayCommand(UpdateVisit);
        }

        public void AddVisit(object parameter)
        {
            SelectedVisit = new Visit();
            OpenVisitInfoWindow();
        }

        public void OpenVisitInfoWindow()
        {
            if (_visitInfoWindow != null)
            {
                _visitInfoWindow.Close();
            }

            _visitInfoWindow = new VisitInfoWindow(
                new VisitStatusRepository(new CarServiceKpzContext()),
                new CarRepository(new CarServiceKpzContext()),
                new EmployeeRepository(new CarServiceKpzContext()),
                new PaymentStatusRepository(new CarServiceKpzContext()),
                this);
            _visitInfoWindow.Show();
        }

        public void SaveVisit(object parameter)
        {
            if (SelectedVisit != null)
            {
                if (SelectedVisit.VisitId == 0)
                {
                    GenerateRandomVisitNumber();
                    _visitRepository.Add(SelectedVisit);
                    UpdateVisitList();
                }
                else
                {
                    _visitRepository.Update(SelectedVisit);
                    UpdateVisitList();
                }
            }
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
                _visitRepository.Delete(SelectedVisit);
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
            Visits.Clear();
            var visits = _visitRepository.GetAll();
            foreach (var visit in visits)
            {
                Visits.Add(visit);
            }
        }
    }
}
