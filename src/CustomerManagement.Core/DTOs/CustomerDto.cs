namespace CustomerManagement.Core.DTOs;

public class CustomerDto
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
}