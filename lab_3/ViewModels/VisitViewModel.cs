using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using lab_3.Command;
using lab_3.InfoWindows;
using Newtonsoft.Json;
using System.Net.Http;
using Abstraction.DTOs;
using System.Text;

namespace lab_3.ViewModels
{
    public class VisitViewModel : BaseViewModel
    {
        private ObservableCollection<VisitDTO> _visits;
        public ObservableCollection<VisitDTO> Visits
        {
            get => _visits;
            set
            {
                if (_visits != value)
                {
                    _visits = value;
                    OnPropertyChanged();
                }
            }
        }

        private VisitDTO _selectedVisit;
        private VisitDTO _editableVisit;
        private VisitInfoWindow _visitInfoWindow;

        public VisitDTO SelectedVisit
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

        public VisitViewModel()
        {
            LoadVisits();
            AddCommand = new RelayCommand(AddVisit);
            SaveCommand = new RelayCommand(SaveVisit);
            CancelCommand = new RelayCommand(Cancel);
            DeleteCommand = new RelayCommand(DeleteVisit);
            UpdateCommand = new RelayCommand(UpdateVisit);
        }

        private async void LoadVisits()
        {
            var response = await HttpClient.GetStringAsync($"{ServiceUrl}api/Visit");
            var visits = JsonConvert.DeserializeObject<List<VisitDTO>>(response);
            if (visits is null)
                return;
            Visits = new ObservableCollection<VisitDTO>(visits);
        }

        public void AddVisit(object parameter)
        {
            SelectedVisit = new VisitDTO();
            OpenVisitInfoWindow();
        }

        public void OpenVisitInfoWindow()
        {
            if (_visitInfoWindow != null)
            {
                _visitInfoWindow.Close();
            }

            _visitInfoWindow = new VisitInfoWindow(this);
            _visitInfoWindow.Show();
        }

        public async void SaveVisit(object parameter)
        {
            if (SelectedVisit == null)
            {
                return;
            }

            if (SelectedVisit.VisitID == 0)
                GenerateRandomVisitNumber();

            var json = JsonConvert.SerializeObject(SelectedVisit);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            if (SelectedVisit.VisitID == 0)
            {
                var response = await HttpClient.PostAsync($"{ServiceUrl}api/Visit", data);
            }
            else
            {
                var response = await HttpClient.PutAsync($"{ServiceUrl}api/Visit/{SelectedVisit.VisitID}", data);
            }
            LoadVisits();
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

        private async void DeleteVisit(object parameter)
        {
            if (SelectedVisit != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete this visit?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var visitId = SelectedVisit.VisitID;
                    var response = await HttpClient.DeleteAsync($"{ServiceUrl}api/Visit/{visitId}");
                    LoadVisits();
                }
            }
            
        }

        private void UpdateVisit(object parameter)
        {
            if (SelectedVisit != null)
            {
                OpenVisitInfoWindow();
            }
        }

    }
}
