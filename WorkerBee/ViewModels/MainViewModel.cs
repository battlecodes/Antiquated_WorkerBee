using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        private NavigationStore _navigationStore;

        private String _statusBarText = "";
        #endregion


        #region Properties

        public ViewModelBase CurrentContentViewModel => _navigationStore.CurrentContentViewModel;


        public String StatusBarText
        {
            get => _statusBarText;
            set
            {
                _statusBarText = value;
                OnPropertyChanged("StatusBarText");
            }
        }
        #endregion


        #region Constructors

        public MainViewModel(NavigationStore navigationStore)
        {


            /// TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING TESTING
            _navigationStore = navigationStore;

            _navigationStore.CurrentContentViewModelChanged += OnCurrentContentViewModelChanged;
        }
        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private void OnCurrentContentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentContentViewModel));
        }


        private void OnStatusUpdate()
        {
            /// I need an event that passes arguments so that I can get a status message here!
            throw new NotImplementedException();
        }
        #endregion
    }
}
