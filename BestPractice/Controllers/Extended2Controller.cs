using BestPractice.Database;
using BestPractice.ExtendedServiceNamespace;
using BestPractice.Factory;
using BestPractice.Inputs;
using BestPractice.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace BestPractice.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Extended2Controller : BaseController
    <Extended2Component,
    Guid,
    Extended2Object,
    Extended2CreateInput,
    Extended2UpdateInput>
{
    public Extended2Controller(IEntityRepository<Extended2Component, Guid> repo, IExtendedService<Extended2CreateInput, Extended2UpdateInput, Extended2Component, Guid> service, IComponentFactory<Extended2Component, Extended2Object> extendedFactory) : base(repo, service, extendedFactory)
    {
        //var test = repo.FindByCondition(x => x.Where(y => true), false);

    }


    [HttpGet(Name = "GetExtendedTwo")]
    public async Task<IActionResult> Get(Guid id)
    {
        return await base.GetAsync(x => x.Where(y => y.Id == id));
        //return new EmptyResult();
    }

    [HttpPost(Name = "PostExtendedTwo")]
    public async Task<IActionResult> Create(Extended2CreateInput input)
    {
        return base.Create(input);
        //return new EmptyResult();
    }






}
