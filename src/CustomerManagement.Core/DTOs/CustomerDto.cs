namespace CustomerManagement.Core.DTOs;

/// <summary>
/// Represents customer data for API responses.
/// </summary>
public class CustomerDto
{
    /// <summary>
    /// The unique identifier for the customer.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// The full name of the customer.
    /// </summary>
    public required string FullName { get; set; }
    
    /// <summary>
    /// The email address of the customer.
    /// </summary>
    public required string Email { get; set; }
}