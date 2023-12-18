using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Moq;

namespace Testing
{
    [TestFixture]
    public class Moq
    {
        [Test]
        public void EmpInfo_ValidProperties_Success()
        {
            // Arrange
            var empInfo = new EmpInfo
            {
                Email = "test@example.com",
                Name = "John Doe",
                DateOfJoining = DateTime.Now,
                PassCode = 1234
            };

            // Act
            // No action required for this test

            // Assert
            Assert.That(empInfo.Email, Is.EqualTo("test@example.com"));
            Assert.That(empInfo.Name, Is.EqualTo("John Doe"));
            Assert.That(empInfo.DateOfJoining, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(1)));
            Assert.That(empInfo.PassCode, Is.EqualTo(1234));
        }

        

        [Test]
        public void EmpInfo_Validation_EmailIsRequired()
        {
            // Arrange
            var empInfo = new EmpInfo();

            // Act
            var validationContext = new ValidationContext(empInfo, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(empInfo, validationContext, validationResults, true);

            // Assert
            Assert.That(validationResults, Has.Count.EqualTo(2));
            Assert.That(validationResults[0].MemberNames, Contains.Item("Email"));
           
        }

        // Add similar tests for other validation attributes as needed

        [Test]
        public void EmpInfo_BlogsCollection_Mocked_Success()
        {
            // Arrange
            var empInfo = new EmpInfo();
            var mockBlogInfo = new Mock<BlogInfo>();

            // Act
            empInfo.Blogs = new List<BlogInfo> { mockBlogInfo.Object };

            // Assert
            Assert.That(empInfo.Blogs, Is.Not.Null);
            Assert.That(empInfo.Blogs, Has.Count.EqualTo(1));
            Assert.That(empInfo.Blogs, Contains.Item(mockBlogInfo.Object));
        }
    }
}
