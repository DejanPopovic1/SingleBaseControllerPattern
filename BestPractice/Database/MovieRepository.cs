namespace BestPractice.Database;

public class MovieRepository(ApplicationContext context) : EntityRepository<Movie, Guid>(context)
{
}
