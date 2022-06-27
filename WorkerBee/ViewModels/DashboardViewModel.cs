using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkerBee.Models;
using WorkerBee.Navigation;
using WorkerBee.Utilities;

namespace WorkerBee.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {

        #region Fields
        /// <summary>
        /// The BookStore reference for this instance.
        /// </summary>
        private readonly BookStore _bookStore;

        private readonly NavigationStore _navigationStore;

        private double dailyOtherHours;

        private double dailyPrimaryHours;

        private double dailyTotalHours;

        private Book? model;

        private double periodOtherHours;

        private double periodPrimaryHours;

        private double periodTotalHours;
        #endregion


        #region Properties
        /// <summary>
        /// The Book reference that is the focus of this viewmodel.
        /// </summary>
        public Book? Model => _bookStore.CurrentBook;


        public double DailyOtherHours
        {
            get => dailyOtherHours;
            set
            {
                dailyOtherHours = value;
                OnPropertyChanged(nameof(DailyOtherHours));
            }
        }


        public double DailyPrimaryHours
        {
            get => dailyPrimaryHours;
            set
            {
                dailyPrimaryHours = value;
                OnPropertyChanged(nameof(DailyPrimaryHours));
            }
        }


        public double DailyTotalHours
        {
            get => dailyTotalHours;
            set
            {
                dailyTotalHours = value;
                OnPropertyChanged(nameof(DailyTotalHours));
            }
        }

        public double PeriodOtherHours
        {
            get => periodOtherHours;
            set
            {
                periodOtherHours = value;
                OnPropertyChanged(nameof(PeriodOtherHours));
            }
        }


        public double PeriodPrimaryHours
        {
            get => periodPrimaryHours;
            set
            {
                periodPrimaryHours = value;
                OnPropertyChanged(nameof(PeriodPrimaryHours));
            }
        }


        public double PeriodTotalHours
        {
            get => periodTotalHours;
            set
            {
                periodTotalHours = value;
                OnPropertyChanged(nameof(PeriodTotalHours));
            }
        }
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DashboardViewModel"/> class.
        /// </summary>
        /// <param name="bookStore"></param>
        public DashboardViewModel(BookStore bookStore,
            NavigationStore navigationStore)
        {
            _bookStore = bookStore;
            _navigationStore = navigationStore;
        }
        #endregion


        #region Public Methods
        
        #endregion
    }
}
