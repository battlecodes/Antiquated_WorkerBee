using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkerBee.Navigation;
using WorkerBee.Models;
using WorkerBee.ViewModels;

namespace WorkerBee.Utilities
{
    public class CreateBookCommand : CommandBase
    {

        #region Fields

        private readonly BookStore _bookStore;


        private readonly CreateNewBookViewModel _viewModel;

        private readonly NavigationService<DashboardViewModel> _navigationService;
        #endregion


        #region Constructors

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
        public override void Execute(object parameter)
        {
            // Create the new book and add it to the book store so that the
            // Dashboard view can access it.
            CreateNewBookModel model = _viewModel.Model;
            MessageBox.Show($"Creating new logbook '{model.Name}'...");
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
