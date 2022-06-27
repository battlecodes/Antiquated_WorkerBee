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
        /// <summary>
        /// NavigationStore reference for this instance.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Callback function for this instance.
        /// </summary>
        private readonly Func<TViewModel> _createViewModel;
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NavigationService{TViewModel}"/> class.
        /// </summary>
        /// <param name="navigationStore"></param>
        /// <param name="createViewModel"></param>
        public NavigationService(NavigationStore navigationStore,
            Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Sets the <see cref="NavigationStore.CurrentContentViewModel"/>
        /// to the <seealso cref="_createViewModel"/> value.
        /// </summary>
        public void Navigate()
        {
            _navigationStore.CurrentContentViewModel = _createViewModel();
        }
        #endregion
    }
}
