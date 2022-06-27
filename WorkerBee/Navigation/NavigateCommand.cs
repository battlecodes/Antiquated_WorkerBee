using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Navigation;
using WorkerBee.Utilities.Commands;
using WorkerBee.ViewModels;

namespace WorkerBee.Navigation
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {

        #region Fields
        /// <summary>
        /// This instance's <see cref="NavigationService{TViewModel}"/> instance.
        /// </summary>
        private readonly NavigationService<TViewModel> _navigationService;
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NavigateCommand{TViewModel}"/> class.
        /// </summary>
        /// <param name="navigationService"></param>
        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Calls the <see cref="NavigationService{TViewModel}.Navigate"/>
        /// method.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
        #endregion
    }
}
