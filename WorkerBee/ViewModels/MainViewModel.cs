using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Navigation;

namespace WorkerBee.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        #region Fields
        private NavigationManager _navigationManager;
        
        private ViewModelBase _currentContentViewModel;
        #endregion


        #region Properties

        public ViewModelBase CurrentContentViewModel
        {
            get => _currentContentViewModel;
            [MemberNotNull(nameof(_currentContentViewModel))]
            set
            {
                _currentContentViewModel = value ??
                    throw new ArgumentNullException(nameof(value));
                OnPropertyChanged("CurrentContentViewModel");
            }
        }
        #endregion


        #region Constructors

        public MainViewModel()
        {
            

            /// TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING
            _navigationManager = new NavigationManager(new DashboardViewModel());
            CurrentContentViewModel = _navigationManager.CurrentContentViewModel;
        }
        #endregion


        #region Public Methods


        #endregion
    }
}
