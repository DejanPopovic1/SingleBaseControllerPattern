using BestPractice.Database;
using BestPractice.Inputs;

namespace BestPractice.ExtendedServiceNamespace;

public interface IExtended2Service <TCreateInput, TUpdateInput, TEntity, TEntityId>
    where TCreateInput : CreateBaseInput
    where TUpdateInput : UpdateBaseInput
    where TEntity : ComponentBase 

{

    public TEntity Create(TCreateInput input);


    public Task<ComponentBase> UpdateAsync(TEntityId id, TUpdateInput input);
}


public class Extended2Service <TCreateInput, TUpdateBaseInput, TEntity, TEntityId> : 
    IExtended2Service <TCreateInput, TUpdateBaseInput, TEntity, TEntityId> 
    where TCreateInput : CreateBaseInput 
    where TEntity : ComponentBase 
    where TUpdateBaseInput : UpdateBaseInput
{
    IEntityRepository<ExtendedComponent, TEntityId> _repository;
    public Extended2Service(IEntityRepository<ExtendedComponent, TEntityId> repository)
    {
        _repository = repository;
    }

    public virtual TEntity Create(TCreateInput input) 
    {
        TEntity component;
        component = Activator.CreateInstance(typeof(TEntity)) as TEntity ?? throw new InvalidOperationException("Component entity could not be constructed");
        component.test1 = input.test1;
        component.test2 = input.test2;
        component.test3 = input.test3;
        _repository.Add(component as ExtendedComponent);
        _repository.SaveChanges();
        return component;
    }

    public virtual async Task<ComponentBase> UpdateAsync(TEntityId id, TUpdateBaseInput input)
    {
        var component = await _repository.FindByIdOrFailAsync(id);
        await UpdateBaseValues(component, input);
        return component;
    }

    protected async Task UpdateBaseValues(ComponentBase component, UpdateBaseInput input)
    {

    }

}
