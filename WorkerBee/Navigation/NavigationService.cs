using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.ViewModels;

namespace WorkerBee.Navigation
{
    public class NavigationService<TViewModel>
        where TViewModel : ViewModelBase
    {

        #region Fields

        private readonly NavigationStore? _navigationStore;

        private readonly Func<TViewModel> _createViewModel;
        #endregion


        #region Constructors

        public NavigationService(NavigationStore navigationStore,
            Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        #endregion


        #region Public Methods

        public void Navigate()
        {
            _navigationStore.CurrentContentViewModel = _createViewModel();
        }
        #endregion
    }
}
