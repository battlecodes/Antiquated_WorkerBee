using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerBee.Models;
using WorkerBee.Utilities.Validators;

namespace WorkerBeeTests.ModelTests
{
    [TestClass]
    public class CreateNewBookModelTests
    {

        #region Constants
        public readonly DateTime today = new DateTime(2022, 5, 6, 0, 0, 0); // May 6th, 2022 12:00:00 AM
        public readonly DateTime tomorrow = new DateTime(2022, 5, 7, 0, 0, 0); // May 7th, 2022 12:00:00 AM
        #endregion


        #region Validate
        [TestMethod, TestCategory("Validate")]
        public void Validate_ValidProperties_ReturnsTrue()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = today,
            };

            (bool result, _) = model.Validate();

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Validate")]
        public void Validate_ValidProperties_ReturnsNone()
        {
            CreateNewBookModel model = new()
            {
                Description = "",
                EndDate = tomorrow,
                Name = "Test Name",
                SaveLocation = "Testlocation",
                StartDate = today,
            };

            (_, NewBookValidationError err) = model.Validate();

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

            (bool result, _) = model.Validate();

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

            (_, NewBookValidationError err) = model.Validate();

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

            (bool result, _) = model.Validate();

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

            (_, NewBookValidationError err) = model.Validate();

            Assert.AreEqual(NewBookValidationError.SaveLocationInvalid, err);
        }
        #endregion
    }
}
