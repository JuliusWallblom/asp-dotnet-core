using CustomerManagement.API.CQRS.Commands;
using CustomerManagement.API.Validators;
using FluentAssertions;
using Xunit;

namespace CustomerManagement.Tests.Validators
{
    public class CreateCustomerCommandValidatorTests
    {
        private readonly CreateCustomerCommandValidator _validator;

        public CreateCustomerCommandValidatorTests()
        {
            _validator = new CreateCustomerCommandValidator();
        }

        [Fact]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("", "Doe", "john@example.com", "FirstName")]
        [InlineData("John", "", "john@example.com", "LastName")]
        [InlineData("John", "Doe", "", "Email")]
        [InlineData("John", "Doe", "invalid-email", "Email")]
        public void Validate_WithInvalidCommand_ShouldHaveValidationError(string firstName, string lastName, string email, string expectedErrorProperty)
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.PropertyName == expectedErrorProperty);
        }
    }
}