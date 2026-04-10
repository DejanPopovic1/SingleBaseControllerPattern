using System.Net;

namespace BestPractice.Exceptions
{
    public class EntityAlreadyExistsException: ApiException
    {
        Type EntityType { get; set; }

        public EntityAlreadyExistsException(Type entityType, object metadata) : base ("Entity Already Exists", HttpStatusCode.InternalServerError, "Entity Already Exists")
        {
            EntityType = entityType;
            ResponseDetail = new { metadata };
        }
    }
}
