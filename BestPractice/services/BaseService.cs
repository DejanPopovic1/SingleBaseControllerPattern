using BestPractice.Database;
using BestPractice.Inputs;

namespace BestPractice.services;



public class BaseService<T, I> where T : ComponentBase
{
    EntityRepository<T, I> _repository;
    public BaseService(EntityRepository<T, I> repository)
    {
        _repository = repository;
    }

    public virtual T Create(CreateBaseInput input)
    {
        T component;
        component = Activator.CreateInstance(typeof(T)) as T ?? throw new InvalidOperationException("Component entity could not be constructed");
        component.test1 = input.test1;
        component.test2 = input.test2;
        component.test3 = input.test3;
        return component;
    }

    public virtual async Task<T> Update(I id, UpdateBaseInput input)
    {
        var component = await _repository.FindByIdOrFailAsync(id);
        await UpdateBaseValues(component, input);
        return component;
    }

    protected async Task UpdateBaseValues(T component, UpdateBaseInput input)
    { 
    
    }

}
