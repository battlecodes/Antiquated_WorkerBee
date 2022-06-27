using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkerBee.Navigation;
using WorkerBee.Utilities;

namespace WorkerBee.ViewModels
{
    public class DashboardNoActiveBookViewModel : ViewModelBase
    {

        #region Fields
        /// <summary>
        /// The NavigationStore reference for this instance.
        /// </summary>
        private NavigationStore? _navigationStore;
        #endregion


        #region Commands
        /// <summary>
        /// Defines the command that is bound to the "Create new
        /// logbook" button.
        /// </summary>
        public ICommand CreateNewLogbookButtonClickCommand { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DashboardNoActiveBookViewModel"/> class.
        /// </summary>
        /// <param name="bookStore"></param>
        /// <param name="navigationStore"></param>
        public DashboardNoActiveBookViewModel(BookStore bookStore,
            NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            // Instantiate commands.
            CreateNewLogbookButtonClickCommand = new
                NavigateCommand<CreateNewBookViewModel>(
                new NavigationService<CreateNewBookViewModel>(_navigationStore,
                () => new CreateNewBookViewModel(bookStore, navigationStore)));

        }
        #endregion
    }
}
