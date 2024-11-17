using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected const string ServiceUrl = "http://localhost:5102/";
        protected readonly HttpClient HttpClient;

        protected BaseViewModel()
        {
            HttpClient = new HttpClient { BaseAddress = new Uri(ServiceUrl) };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
