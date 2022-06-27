using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Models;

namespace WorkerBee.Utilities.Validators
{
    public enum NewBookValidationError
    {
        None,
        DatesNonChronological,
        SaveLocationInvalid,
    }


    public class NewBookValidator : IValidate<NewBookValidationError>
    {

        #region Properties
        /// <summary>
        /// Model whose properties are to be validated.
        /// </summary>
        public CreateNewBookModel? Model { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NewBookValidator"/>
        /// class.
        /// </summary>
        public NewBookValidator() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewBookValidator"/>
        /// class with a defined <seealso cref="Model"/>.
        /// </summary>
        /// <param name="model"></param>
        public NewBookValidator(CreateNewBookModel model)
        {
            Model = model;
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Tests if the <seealso cref="Model"/>'s properties are valid.
        /// </summary>
        /// <returns>(Tuple) False if the properties are invalid,
        /// True otherwise, and the NewBookValidationError enum
        /// for the invalid property.</returns>
        /// <exception cref="InvalidOperationException">Thrown if Model is
        /// null.</exception>
        public (bool, NewBookValidationError) Validate()
        {
            // Check for null Model.
            if (Model == null)
            {
                throw new InvalidOperationException("validator's Model property " +
                    "is null");
            }

            // Validate that the dates are chronological.
            if (!ValidateDates())
            {
                return (false, NewBookValidationError.DatesNonChronological);
            }

            // Validate the save directory string is valid.
            if (!ValidateSaveLocation())
            {
                return(false, NewBookValidationError.SaveLocationInvalid);
            }

            return (true, NewBookValidationError.None);
        }

        /// <summary>
        /// Tests if the <seealso cref="CreateNewBookModel"/>'s properties are valid.
        /// </summary>
        /// <param name="model">CreateNewBookModel to validate.</param>
        /// <returns>(Tuple) False if the properties are invalid,
        /// True otherwise, and the NewBookValidationError enum
        /// for the invalid property.</returns>
        /// <exception cref="InvalidOperationException">Thrown if Model is
        /// null.</exception>
        public (bool, NewBookValidationError) Validate(CreateNewBookModel model)
        {
            Model = model;
            (bool result, NewBookValidationError error) = Validate();

            // Reset this instance's Model property to null.
            Model = null;

            return (result, error);
        }
        #endregion


        #region Private Methods
        /// <summary>
        /// Tests if the <seealso cref="Model"/>'s start and end
        /// dates are chronological.
        /// </summary>
        /// <returns>True if the dates are chronological, False
        /// otherwise.</returns>
        private bool ValidateDates()
        {
            return Model.StartDate <= Model.EndDate;
        }

        /// <summary>
        /// Tests if the <seealso cref="Model"/>'s save location is
        /// a valid directory path.
        /// </summary>
        /// <returns>True if the location is a valid directory path,
        /// False otherwise.</returns>
        private bool ValidateSaveLocation()
        {
            try
            {
                if (!Directory.Exists(Model.SaveLocation))
                {
                    DirectoryInfo path = Directory.CreateDirectory(Model.SaveLocation);
                    Directory.Delete(path.FullName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
