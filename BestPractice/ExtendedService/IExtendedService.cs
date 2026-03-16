using BestPractice.Database;
using BestPractice.Inputs;

namespace BestPractice.ExtendedServiceNamespace;

public interface IExtendedService <TCreateInput, TUpdateInput, TEntity, TEntityId>
    where TCreateInput : CreateBaseInput
    where TUpdateInput : UpdateBaseInput
    where TEntity : ComponentBase 

{

    public TEntity Create(TCreateInput input);


    public Task<ComponentBase> UpdateAsync(TEntityId id, TUpdateInput input);
}


public class ExtendedService <TCreateInput, TUpdateBaseInput, TEntity, TEntityId> : 
    IExtendedService <TCreateInput, TUpdateBaseInput, TEntity, TEntityId> 
    where TCreateInput : CreateBaseInput 
    where TEntity : ComponentBase 
    where TUpdateBaseInput : UpdateBaseInput
{
    IEntityRepository<ComponentBase, TEntityId> _repository;
    public ExtendedService(IEntityRepository<ComponentBase, TEntityId> repository)
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
        _repository.Add(component);
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
