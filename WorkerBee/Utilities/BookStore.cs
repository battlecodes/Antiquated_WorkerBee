using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Models;

namespace WorkerBee.Utilities
{
    public class BookStore
    {

        #region Fields
        private Book? _currentBook;
        #endregion


        #region Properties
        /// <summary>
        /// Book reference for this instance.
        /// </summary>
        public Book? CurrentBook { get; set; }
        #endregion
    }
}
