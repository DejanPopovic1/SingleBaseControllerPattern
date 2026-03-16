namespace BestPractice.Database;

public class ActorRepository(ApplicationContext context) : EntityRepository<Actor, Guid>(context)
{
}
