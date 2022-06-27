using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Models;
using WorkerBee.Utilities.Validators;

namespace WorkerBeeTests.UtilitiesTests.ValidatorTests
{
    [TestClass]
    public class NewBookValidatorTests
    {

        #region Constants
        public readonly DateTime today = new DateTime(2022, 5, 6, 0, 0, 0); // May 6th, 2022 12:00:00 AM
        public readonly DateTime tomorrow = new DateTime(2022, 5, 7, 0, 0, 0); // May 7th, 2022 12:00:00 AM
        #endregion


        #region Validate (parameterless)
        [TestMethod, TestCategory("ParameterlessValidate")]
        public void ParameterlessValidate_ModelPropertiesValid_ReturnsTrue()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = today,
            };
            NewBookValidator v = new(model);

            (bool result, _) = v.Validate();

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("ParameterlessValidate")]
        public void ParameterlessValidate_ModelPropertiesValid_ReturnsNone()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = today,
            };
            NewBookValidator v = new(model);

            (_, NewBookValidationError err) = v.Validate();

            Assert.AreEqual(NewBookValidationError.None, err);
        }

        [TestMethod, TestCategory("ParameterlessValidate")]
        public void ParameterlessValidate_DatesNotChronological_ReturnsFalse()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = today,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = tomorrow,
            };
            NewBookValidator v = new(model);

            (bool result, _) = v.Validate();

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("ParameterlessValidate")]
        public void ParameterlessValidate_DatesNotChronlogical_ReturnsDatesNonChronological()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = today,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = tomorrow,
            };
            NewBookValidator v = new(model);

            (_, NewBookValidationError err) = v.Validate();

            Assert.AreEqual(NewBookValidationError.DatesNonChronological, err);
        }

        [TestMethod, TestCategory("ParameterlessValidate")]
        public void ParameterlessValidate_InvalidSaveLocation_ReturnsFalse()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "D:\\bad$location*&%",
                StartDate = today,
            };
            NewBookValidator v = new(model);

            (bool result, _) = v.Validate();

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("ParameterlessValidate")]
        public void ParameterlessValidate_SaveLocationInvalid_ReturnsSaveLocationInvalid()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "D:\\bad$location*&%",
                StartDate = today,
            };
            NewBookValidator v = new(model);

            (_, NewBookValidationError err) = v.Validate();

            Assert.AreEqual(NewBookValidationError.SaveLocationInvalid, err);
        }
        #endregion


        #region Validate
        [TestMethod, TestCategory("Validate")]
        public void Validate_ModelPropertiesValid_ReturnsTrue()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = today,
            };
            NewBookValidator v = new();

            (bool result, _) = v.Validate(model);

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Validate")]
        public void Validate_ModelPropertiesValid_ReturnsNone()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = today,
            };
            NewBookValidator v = new();

            (_, NewBookValidationError err) = v.Validate(model);

            Assert.AreEqual(NewBookValidationError.None, err);
        }

        [TestMethod, TestCategory("Validate")]
        public void Validate_DatesNotChronological_ReturnsFalse()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = today,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = tomorrow,
            };
            NewBookValidator v = new();

            (bool result, _) = v.Validate(model);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("Validate")]
        public void Validate_DatesNotChronlogical_ReturnsDatesNonChronological()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = today,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = tomorrow,
            };
            NewBookValidator v = new();

            (_, NewBookValidationError err) = v.Validate(model);

            Assert.AreEqual(NewBookValidationError.DatesNonChronological, err);
        }

        [TestMethod, TestCategory("Validate")]
        public void Validate_InvalidSaveLocation_ReturnsFalse()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "D:\\bad$location*&%",
                StartDate = today,
            };
            NewBookValidator v = new();

            (bool result, _) = v.Validate(model);

            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("Validate")]
        public void Validate_SaveLocationInvalid_ReturnsSaveLocationInvalid()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "D:\\bad$location*&%",
                StartDate = today,
            };
            NewBookValidator v = new();

            (_, NewBookValidationError err) = v.Validate(model);

            Assert.AreEqual(NewBookValidationError.SaveLocationInvalid, err);
        }
        #endregion
    }
}
