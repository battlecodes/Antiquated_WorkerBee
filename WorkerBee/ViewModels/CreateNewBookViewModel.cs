using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkerBee.Models;
using WorkerBee.Navigation;
using WorkerBee.Utilties;

namespace WorkerBee.ViewModels
{
    public class CreateNewBookViewModel : ViewModelBase
    {

        #region Fields

        private DateTime endDate;

        private bool isCreatePossible = false;

        private string nameText;

        private NavigationStore _navigationStore;

        private DateTime startDate;
        #endregion


        #region Properties
        private string descriptionText;
        public string DescriptionText
        {
            get => descriptionText;
            set
            {
                descriptionText = value;
                OnPropertyChanged(nameof(DescriptionText));
            }
        }


        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(DescriptionText));
            }
        }


        public bool IsCreatePossible
        {
            get => isCreatePossible;
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
            }
        }


        public CreateNewBookModel Model { get; set; }


        public string SaveLocationText { get; set; }


        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        #endregion


        #region Event Handlers

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion


        #region Commands

        public ICommand BrowseButtonClickCommand { get; set; }


        public ICommand CancelButtonClickCommand { get; set; }


        public ICommand CreateButtonClickCommand { get; set; }
        #endregion


        #region Constructors

        public CreateNewBookViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            StartDate = DateTime.Now;
            EndDate = StartDate.AddYears(1);
            //NameText = "Testing";

            // Instantiate commands.
            BrowseButtonClickCommand = new RelayCommand(
                new Action<object>(ShowBrowseFolderDialog));
            CancelButtonClickCommand = new NavigateCommand<DashboardNoActiveBookViewModel>(_navigationStore,
                () => new DashboardNoActiveBookViewModel(_navigationStore));
            CreateButtonClickCommand = new RelayCommand(
                new Action<object>(CreateNewBookRequested));
        }
        #endregion


        #region Public Methods

        public override void OnPropertyChanged(string? name = null)
        {
            // If the text in the NameTextBox is changed, check if the
            // text box is empty and set the CreateButton enabled state.
            if (name == nameof(NameText))
            {
                IsCreatePossible = !string.IsNullOrEmpty(NameText);
                DescriptionText = "Diggity";
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion


        #region Private Methods

        private void CreateNewBookRequested(object obj)
        {
            throw new NotImplementedException();
        }


        private void ShowBrowseFolderDialog(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
