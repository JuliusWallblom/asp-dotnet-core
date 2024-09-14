namespace CustomerManagement.API.GraphQL;

public class OperationResult<T>
{
    public bool Successful { get; set; }
    public T? Data { get; set; }
    public List<UserError>? Errors { get; set; }
}

public record UserError(string Message, string? PropertyName = null);