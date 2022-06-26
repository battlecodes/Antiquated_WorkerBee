using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Models;
using WorkerBee.Utilities;

namespace WorkerBee.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {

        #region Fields

        private readonly BookStore _bookStore;
        #endregion


        #region Properties

        public Book? CurrentBook => _bookStore.CurrentBook;
        #endregion


        #region Constructors

        public DashboardViewModel(BookStore bookStore)
        {
            _bookStore = bookStore;
        }
        #endregion
    }
}
