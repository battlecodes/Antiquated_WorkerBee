using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Navigation;
using WorkerBee.Utilities;
using WorkerBee.ViewModels;

namespace WorkerBee.Navigation
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;


        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }


        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
