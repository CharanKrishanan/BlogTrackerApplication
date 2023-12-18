using System.ComponentModel.DataAnnotations;
using DAL;

namespace Testing
{
    [TestFixture]
    public class AdminInfoTests
    {
        [Test]
        public void ValidAdminInfo_ShouldPassValidation()
        {
            // Arrange
            var adminInfo = new AdminInfo
            {
                Email = "admin@example.com",
                Password = "SecurePassword123"
            };

            // Act
            var validationContext = new ValidationContext(adminInfo, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, true);

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void InvalidAdminInfo_MissingEmail_ShouldFailValidation()
        {
            // Arrange
            var adminInfo = new AdminInfo
            {
                Password = "SecurePassword123"
            };

            // Act
            var validationContext = new ValidationContext(adminInfo, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Email field is required.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void InvalidAdminInfo_InvalidEmailFormat_ShouldFailValidation()
        {
            // Arrange
            var adminInfo = new AdminInfo
            {
                Email = "invalid-email",
                Password = "SecurePassword123"
            };

            // Act
            var validationContext = new ValidationContext(adminInfo, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(adminInfo, validationContext, validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Email field is not a valid e-mail address.", validationResults[0].ErrorMessage);
        }

        // Add more test cases as needed for other scenarios.
    }
}