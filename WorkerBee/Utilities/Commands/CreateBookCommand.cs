using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkerBee.Navigation;
using WorkerBee.Models;
using WorkerBee.ViewModels;

namespace WorkerBee.Utilities.Commands
{
    public class CreateBookCommand : CommandBase
    {

        #region Fields
        /// <summary>
        /// BookStore reference for this instance.
        /// </summary>
        private readonly BookStore _bookStore;

        /// <summary>
        /// CreateNewBookViewModel reference for this instance.
        /// </summary>
        private readonly CreateNewBookViewModel _viewModel;

        /// <summary>
        /// NavigationService reference for this instance.
        /// </summary>
        private readonly NavigationService<DashboardViewModel> _navigationService;
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBookCommand"/>
        /// class.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="bookStore"></param>
        /// <param name="navigationService"></param>
        public CreateBookCommand(CreateNewBookViewModel viewModel,
            BookStore bookStore,
            NavigationService<DashboardViewModel> navigationService)
        {
            _bookStore = bookStore;
            _viewModel = viewModel;
            _navigationService = navigationService;
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Creates a new <see cref="Book"/> object, sets a reference of it
        /// to <see cref="_bookStore.CurrentContentViewModel"/>, and calls
        /// the <see cref="_navigationService.Navigate"/> method.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            // Create the new book and add it to the book store so that the
            // Dashboard view can access it.
            CreateNewBookModel model = _viewModel.Model;
            Book newBook = new()
            {
                Description = model.Description,
                EndDate = model.EndDate,
                Name = model.Name,
                SaveLocation = model.SaveLocation,
                StartDate = model.StartDate,
            };
            _bookStore.CurrentBook = newBook;

            // Navigate to the Dashboard view.
            _navigationService.Navigate();
        }
        #endregion
    }
}
