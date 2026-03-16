namespace BestPractice.Database;

public class ExtendedRepository : EntityRepository<ExtendedComponent, Guid>
{
    public ExtendedRepository(ApplicationContext context) : base (context)
    { 
    
    }
}
