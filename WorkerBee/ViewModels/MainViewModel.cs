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
        /// <summary>
        /// The NavigationStore reference for this instance.
        /// </summary>
        private NavigationStore _navigationStore;

        private String _statusBarText = "";
        #endregion


        #region Properties
        /// <summary>
        /// The current viewmodel that is the focus of the main viewer
        /// ContentControl.
        /// </summary>
        public ViewModelBase CurrentContentViewModel => _navigationStore.CurrentContentViewModel;

        /// <summary>
        /// String that defines the text of the status bar.
        /// </summary>
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
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/>
        /// class.
        /// </summary>
        /// <param name="navigationStore"></param>
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentContentViewModelChanged += OnCurrentContentViewModelChanged;
        }
        #endregion


        #region Public Methods


        #endregion


        #region Private Methods
        /// <summary>
        /// Calls the <see cref="ViewModelBase.OnPropertyChanged(string?)"/>
        /// method.
        /// </summary>
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
