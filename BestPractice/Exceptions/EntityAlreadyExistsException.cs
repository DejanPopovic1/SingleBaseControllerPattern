namespace BestPractice.Exceptions
{
    public class EntityAlreadyExistsException(string? message): ApiException(message ?? "Unknown")
    {

    }
}
