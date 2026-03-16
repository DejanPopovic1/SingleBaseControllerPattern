using BestPractice.Database;
using BestPractice.Exceptions;
using BestPractice.ExtendedServiceNamespace;
using BestPractice.Factory;
using BestPractice.Inputs;
using BestPractice.Outputs;
using BestPractice.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BestPractice.Controllers;

public class BaseController<
    TEntity, 
    TEntityId, 
    TObject, 
    TCreateInput, 
    TUpdateInput
    > : ControllerBase
    where TEntity : ComponentBase
 
    where TObject : BaseObject
    where TCreateInput : CreateBaseInput
    where TUpdateInput : UpdateBaseInput


    //ExtendedComponent,
    //Guid,
    //ExtendedObject,
    //ExtendedCreateInput,
    //ExtendedUpdateInput
{

    protected readonly IEntityRepository<TEntity , TEntityId> _entityRepository;
    protected readonly IExtendedService<TCreateInput, TUpdateInput, TEntity, TEntityId> _service;
    protected readonly IComponentFactory<TEntity, TObject> _factory;

    public BaseController(
        IEntityRepository<TEntity, TEntityId> repository,
        IExtendedService<TCreateInput, TUpdateInput, TEntity, TEntityId> service,
        IComponentFactory<TEntity, TObject> factory
        )
    {
        _entityRepository = repository;
        _service = service;
        _factory = factory;
    }

    [NonAction]
    public virtual IActionResult Create(TCreateInput input)
    {
        try
        {
            TEntity component;
            component = _service.Create(input);
            return Ok(ApiResponseHelper.CreateSuccessResponse(_factory.Make(component)));
        }
        catch (EntityAlreadyExistsException ex)
        {
            ApiResponse<dynamic> response = ApiResponseHelper.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message, ex);
            return Conflict(response);
        }
        // return new EmptyResult();
    }

    [NonAction]
    public virtual async Task<IActionResult> UpdateAsync(
        TEntityId id,
        TUpdateInput input
    )
    {
        //var component = await _service.UpdateAsync(id, input);
        //var result = _factory.Make(component);
        //return Ok(ApiResponseHelper.CreateSuccessResponse(result));
        return new EmptyResult();
    }

    protected async virtual Task<IActionResult> ListAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> filter, bool disableTracking = false, bool isIncludeDeleted = false)
    {
        //List<TEntity> components = await _entityRepository.FindAllByConditionAsync(filter, disableTracking);
        //return Ok(ApiResponseHelper.CreateSuccessResponse(_factory.MakeMany(components)));
        return new EmptyResult();
    }

    protected async virtual Task<IActionResult> GetAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> filter, bool disableTracking = false, bool isIncludeDeleted = false)
    {
        //var component = await _entityRepository.FindByConditionOrFailAsync(filter, disableTracking);
        //return Ok(ApiResponseHelper.CreateSuccessResponse(_factory.Make(component)));
        return new EmptyResult();
    }

}
