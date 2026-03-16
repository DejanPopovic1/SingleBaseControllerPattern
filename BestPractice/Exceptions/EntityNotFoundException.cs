using System.Net;

namespace BestPractice.Exceptions;
public class EntityNotFoundException : ApiException
{
    Type EntityType { get; set; }
    public EntityNotFoundException(Type entityType, object metadata) : base(
        "Entity not found",
        HttpStatusCode.NotFound,
        "Entity not found"
      )
    {
        EntityType = entityType;
        ResponseDetail = new { metadata };
    }
}
