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
using WorkerBee.Utilities.Commands;
using WorkerBee.Utilities.Validators;

namespace WorkerBee.ViewModels
{
    public class CreateNewBookViewModel : ViewModelBase, IDataErrorInfo
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
        /// <summary>
        /// String defining the details of this instace.
        /// </summary>
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

        /// <summary>
        /// Date defining the ending date of this instance.
        /// </summary>
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(DescriptionText));
                OnPropertyChanged(nameof(IsCreatePossible));

                Model.EndDate = EndDate;

                // Ensure that the StartDate property is also
                // pushed to the view.
                OnPropertyChanged(nameof(StartDate));
            }
        }

        /// <summary>
        /// Boolean that defines whether the model can be created.
        /// </summary>
        public bool IsCreatePossible
        {
            get => !(string.IsNullOrEmpty(saveLocationText) ||
                string.IsNullOrEmpty(NameText) ||
                StartDate >= EndDate);
            set
            {
                isCreatePossible = value;
                OnPropertyChanged(nameof(IsCreatePossible));
            }
        }

        /// <summary>
        /// String defining the name of this instance.
        /// </summary>
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

        /// <summary>
        /// The model for this instance.
        /// </summary>
        public CreateNewBookModel Model { get; set; } =
            new CreateNewBookModel();

        /// <summary>
        /// String defining the save directory path for this instance.
        /// </summary>
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

        /// <summary>
        /// Date defining the starting date of this instance.
        /// </summary>
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
                OnPropertyChanged(nameof(IsCreatePossible));

                Model.StartDate = StartDate;

                // Ensure that the EndDate property is also
                // pushed to the view.
                OnPropertyChanged(nameof(EndDate));
            }
        }
        #endregion


        #region IDataErrorInfo Members
        public string Error => string.Empty;
        
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;

                if (columnName == "StartDate" || columnName == "EndDate")
                {
                    if (StartDate >= EndDate)
                    {
                        result = "Start and end dates must be chronological";
                    }
                }
                else if(columnName == "NameText")
                {
                    if (string.IsNullOrEmpty(NameText))
                    {
                        result = "Name is required";
                    }
                }

                return result;
            }
        }
        #endregion


        #region Commands
        /// <summary>
        /// Defines the command that is bound to the "Browse"
        /// button.
        /// </summary>
        public ICommand BrowseButtonClickCommand { get; set; }

        /// <summary>
        /// Defines the command that is bound to the "Cancel" button.
        /// </summary>
        public ICommand CancelButtonClickCommand { get; set; }

        /// <summary>
        /// Defines the command that is bound to the "Create Logbook"
        /// button.
        /// </summary>
        public ICommand CreateButtonClickCommand { get; set; }

        /// <summary>
        /// Defines the command that will begin the processes to create
        /// a new book and navigate to the Dashboard view.
        /// </summary>
        public ICommand CreateNewBookCommand { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CreateNewBookViewModel"/> class.
        /// </summary>
        /// <param name="bookStore"></param>
        /// <param name="navigationStore"></param>
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
                () => new DashboardViewModel(bookStore, navigationStore)));
        }
        #endregion


        #region Private Methods
        /// <summary>
        /// Tests if the <seealso cref="Model"/>'s properties are valid, and if so,
        /// executes the <seealso cref="CreateNewBookCommand"/> command.
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="InvalidOperationException">Thrown if the Model is
        /// null.</exception>
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

        /// <summary>
        /// Sets the <seealso cref="StartDate"/> and
        /// <seealso cref="EndDate"/> properties to default values.
        /// </summary>
        private void SetDefaultDates()
        {
            StartDate = DateTime.Now;
            EndDate = StartDate.AddYears(1);
        }

        /// <summary>
        /// Displays the Browse Folder Dialog and, if accepted, sets the
        /// <seealso cref="SaveLocationText"/> property to the selected path.
        /// </summary>
        /// <param name="obj"></param>
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
