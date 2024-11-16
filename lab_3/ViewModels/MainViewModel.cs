using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.ViewModels
{
    public class MainViewModel
    {
        public CarViewModel CarViewModel { get; }
        public CustomerViewModel CustomerViewModel { get; }
        public VisitViewModel VisitViewModel { get; }

        public MainViewModel(
            CarViewModel carViewModel,
            CustomerViewModel customerViewModel,
            VisitViewModel visitVIewModel) 
        {
            CarViewModel = carViewModel ?? throw new ArgumentNullException(nameof(carViewModel));
            CustomerViewModel = customerViewModel ?? throw new ArgumentNullException(nameof(customerViewModel));
            VisitViewModel = visitVIewModel ?? throw new ArgumentNullException(nameof(visitVIewModel));
        }
    }
}