using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using WorkerBee.Models;
using WorkerBee.Navigation;
using WorkerBee.Utilities;
using WorkerBee.Utilities.Validators;

namespace WorkerBee.ViewModels
{
    public class CreateNewBookViewModel : ViewModelBase
    {

        #region Fields


        private string descriptionText = "";

        private DateTime endDate;

        private bool isCreatePossible = false;

        private string nameText = "";

        private readonly NavigationStore _navigationStore;

        private string saveLocationText = "";

        private DateTime startDate;
        #endregion


        #region Properties
        
        public string DescriptionText
        {
            get => descriptionText;
            set
            {
                descriptionText = value;
                OnPropertyChanged(nameof(DescriptionText));

                Model.Description = DescriptionText;
            }
        }


        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(DescriptionText));

                Model.EndDate = EndDate;
            }
        }


        public bool IsCreatePossible
        {
            get => !(string.IsNullOrEmpty(saveLocationText) ||
                string.IsNullOrEmpty(NameText));
            set
            {
                isCreatePossible = value;
                OnPropertyChanged(nameof(IsCreatePossible));
            }
        }


        public string NameText
        {
            get => nameText;
            set
            {
                nameText = value;
                OnPropertyChanged(nameof(NameText));
                OnPropertyChanged(nameof(IsCreatePossible));

                Model.Name = NameText;
            }
        }


        public CreateNewBookModel Model { get; set; } =
            new CreateNewBookModel();


        public string SaveLocationText
        {
            get => saveLocationText;
            set
            {
                saveLocationText = value;
                OnPropertyChanged(nameof(SaveLocationText));
                OnPropertyChanged(nameof(IsCreatePossible));

                Model.SaveLocation = SaveLocationText;
            }
        }


        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));

                Model.StartDate = StartDate;
            }
        }
        #endregion


        #region Commands

        public ICommand BrowseButtonClickCommand { get; set; }


        public ICommand CancelButtonClickCommand { get; set; }


        public ICommand CreateButtonClickCommand { get; set; }


        public ICommand CreateNewBookCommand { get; set; }
        #endregion


        #region Constructors

        public CreateNewBookViewModel(BookStore bookStore, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            SetDefaultDates();

            // Instantiate commands.
            BrowseButtonClickCommand = new RelayCommand(
                new Action<object>(ShowBrowseFolderDialog));
            CancelButtonClickCommand = new NavigateCommand<DashboardNoActiveBookViewModel>(
                new NavigationService<DashboardNoActiveBookViewModel>(_navigationStore,
                () => new DashboardNoActiveBookViewModel(bookStore, _navigationStore)));
            CreateButtonClickCommand = new RelayCommand(
                new Action<object>(CreateNewBookRequested));
            CreateNewBookCommand = new CreateBookCommand(this, bookStore,
                new NavigationService<DashboardViewModel>(_navigationStore,
                () => new DashboardViewModel(bookStore)));
        }
        #endregion


        #region Public Methods

        // THIS CAUSED PROBLEMS WITH THE BINDING OF THE ISCREATEPOSSIBLE PROPERTY
        // TO THE CREATE LOGBOOK BUTTON'S ISENABLED PROPERTY. IT SHOULD STAY REMOVED.
        //public override void OnPropertyChanged(string? name)
        //{
        //    // If the text in the NameTextBox is changed, check if the
        //    // text box is empty and set the CreateButton enabled state.
        //    //if (name == nameof(NameText))
        //    //{
        //    //    IsCreatePossible = !string.IsNullOrEmpty(NameText);
        //    //    DescriptionText = "Diggity";
        //    //}

        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
        #endregion


        #region Private Methods

        private void CreateNewBookRequested(object obj)
        {
            // Check for null model.
            if (Model == null)
            {
                throw new InvalidOperationException("instance's Model property is " +
                    "null");
            }

            // Validate the new book model.
            (bool result, NewBookValidationError error) = Model.Validate();
            if (!result)
            {
                string msg = "An unknown error occurred.";
                string caption = "Unknown Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                if (error == NewBookValidationError.DatesNonChronological)
                {
                    msg = "The start and end dates must be chronological.";
                    caption = "Nonchronological Dates Error";
                    SetDefaultDates();

                }
                else if (error == NewBookValidationError.SaveLocationInvalid){
                    msg = "The selected save location is not valid.";
                    caption = "Invalid Save Location Error";
                }

                System.Windows.MessageBox.Show(msg, caption, button, icon);
            }
            else
            {
                CreateNewBookCommand.Execute(obj);
            }
        }


        private void SetDefaultDates()
        {
            StartDate = DateTime.Now;
            EndDate = StartDate.AddYears(1);
        }


        private void ShowBrowseFolderDialog(object obj)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                SaveLocationText = dlg.SelectedPath;
            }
        }
        #endregion
    }
}
