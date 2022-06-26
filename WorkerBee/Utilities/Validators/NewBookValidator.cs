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

        public CreateNewBookModel? Model { get; set; }
        #endregion


        #region Constructors

        public NewBookValidator() { }


        public NewBookValidator(CreateNewBookModel model)
        {
            Model = model;
        }
        #endregion


        #region Public Methods

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

        private bool ValidateDates()
        {
            return Model.StartDate <= Model.EndDate;
        }


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
