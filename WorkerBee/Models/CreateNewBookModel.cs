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

        #region Properties

        public string Description { get; set; } = "";


        public DateTime EndDate { get; set; }


        public string Name { get; set; } = "";


        public string SaveLocation { get; set; } = "";


        public DateTime StartDate { get; set; }
        #endregion


        #region Public Methods

        public (bool, NewBookValidationError) Validate()
        {
            NewBookValidator validator = new();
            return validator.Validate(this);
        }
        #endregion
    }
}
