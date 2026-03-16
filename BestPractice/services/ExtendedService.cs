using BestPractice.Database;

namespace BestPractice.services;

public class ExtendedService : BaseService<ExtendedComponent, Guid>, IApiService
{
    ExtendedService(ExtendedRepository extendedRepo)
        : base (extendedRepo)
    { 
    
    }

}
