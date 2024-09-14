using System.Threading;
using System.Threading.Tasks;
using CustomerManagement.API.CQRS.Commands;
using CustomerManagement.API.GraphQL;
using CustomerManagement.Core.DTOs;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Moq;
using Xunit;

namespace CustomerManagement.Tests.Mutations
{
    public class CreateCustomerMutationTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mutation _mutation;

        public CreateCustomerMutationTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _mutation = new Mutation();
        }

        [Fact]
        public async Task CreateCustomer_WithValidData_ShouldReturnSuccessResult()
        {
            // Arrange
            var expectedCustomer = new CustomerDto { Id = 1, FullName = "John Doe", Email = "john@example.com" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCustomerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedCustomer);

            // Act
            var result = await _mutation.CreateCustomer(_mediatorMock.Object, "John", "Doe", "john@example.com");

            // Assert
            result.Successful.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(expectedCustomer);
            result.Errors.Should().BeNull();
        }

        [Fact]
        public async Task CreateCustomer_WithInvalidData_ShouldReturnErrorResult()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCustomerCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ValidationException(new[] 
                { 
                    new ValidationFailure("Email", "Invalid email format") 
                }));

            // Act
            var result = await _mutation.CreateCustomer(_mediatorMock.Object, "John", "Doe", "invalid-email");

            // Assert
            result.Successful.Should().BeFalse();
            result.Data.Should().BeNull();
            result.Errors.Should().NotBeNull();
            if (result.Errors != null)
            {
                result.Errors.Should().HaveCount(1);
                result.Errors[0].Message.Should().Be("Invalid email format");
                result.Errors[0].PropertyName.Should().Be("Email");
            }
        }
    }
}