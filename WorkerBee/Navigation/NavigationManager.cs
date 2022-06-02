using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.ViewModels;

namespace WorkerBee.Navigation
{
    internal class NavigationManager : INavigate, INotifyPropertyChanged
    {

        #region Fields
        private ViewModelBase _currentContentViewModel;
        #endregion


        #region Properties

        public ViewModelBase CurrentContentViewModel
        {
            get => _currentContentViewModel;
            [MemberNotNull(nameof(_currentContentViewModel))]
            set
            {
                _currentContentViewModel = value ?? throw new ArgumentNullException(nameof(value));
                OnPropertyChanged("CurrentContentViewModel");
            }
        }
        #endregion


        #region Event Handlers

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion


        #region Constructors

        public NavigationManager(ViewModelBase viewModel)
        {
            CurrentContentViewModel = viewModel;
        }
        #endregion


        #region Private Methods

        private void OnPropertyChanged(string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
