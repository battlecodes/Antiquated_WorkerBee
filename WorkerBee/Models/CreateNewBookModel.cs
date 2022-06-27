using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Utilities.Validators;

namespace WorkerBee.Models
{
    public class CreateNewBookModel
    {

        #region Fields
        private DateTime endDate;

        private DateTime startDate;
        #endregion


        #region Properties
        /// <summary>
        /// Details describing this instance.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Date that this instance ends.
        /// </summary>
        public DateTime EndDate
        {
            get => endDate;
            set => endDate = value.Date;
        }
        //public DateTime EndDate { get; set; }

        /// <summary>
        /// The name of this instance.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The directory where this location is saved.
        /// </summary>
        public string SaveLocation { get; set; } = "";

        /// <summary>
        /// Date that this instance starts.
        /// </summary>
        public DateTime StartDate
        {
            get => startDate;
            set => startDate = value.Date;
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Validates the properties of this instance that will
        /// be used to create a new <see cref="Book"/> object.
        /// </summary>
        /// <returns>(Tuple) False if the properties are invalid,
        /// True otherwise, and the NewBookValidationError enum
        /// for the invalid property.</returns>
        public (bool, NewBookValidationError) Validate()
        {
            NewBookValidator validator = new();
            return validator.Validate(this);
        }
        #endregion
    }
}
