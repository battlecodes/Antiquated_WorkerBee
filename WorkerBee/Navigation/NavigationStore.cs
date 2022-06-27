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
    public class NavigationStore
    {

        public event Action? CurrentContentViewModelChanged;


        #region Fields
        private ViewModelBase? _currentContentViewModel;
        #endregion


        #region Properties

        public ViewModelBase? CurrentContentViewModel
        {
            get => _currentContentViewModel;
            set
            {
                _currentContentViewModel = value ?? throw new ArgumentNullException(nameof(value));
                OnCurrentContentViewModelChanged();
            }
        }
        #endregion



        #region Public Methods

        #endregion


        #region Private Methods

        private void OnCurrentContentViewModelChanged()
        {
            CurrentContentViewModelChanged?.Invoke();
        }
        #endregion
    }
}
