using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkerBee.Navigation;
using WorkerBee.Utilties;

namespace WorkerBee.ViewModels
{
    public class DashboardNoActiveBookViewModel : ViewModelBase
    {

        #region Fields

        private NavigationStore? _navigationStore;
        #endregion


        #region Commands

        public ICommand CreateNewLogbookButtonClickCommand { get; set; }
        #endregion


        #region Constructors

        public DashboardNoActiveBookViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            // Instantiate commands.
            CreateNewLogbookButtonClickCommand = new
                NavigateCommand<CreateNewBookViewModel>(navigationStore,
                () => new CreateNewBookViewModel(navigationStore));

        }
        #endregion


        #region Public Methods

       
        #endregion


        #region Private Methods

        
        #endregion
    }
}
