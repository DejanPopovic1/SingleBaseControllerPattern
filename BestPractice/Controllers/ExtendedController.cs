using Microsoft.AspNetCore.Mvc;
using BestPractice.Database;
using BestPractice.Outputs;
using BestPractice.Inputs;
using BestPractice.Factory;
using BestPractice.services;
using System.Net;
using BestPractice.ExtendedServiceNamespace;

namespace BestPractice.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]


public class ExtendedController : BaseController<
    ExtendedComponent,
    Guid,
    ExtendedObject,
    ExtendedCreateInput,
    ExtendedUpdateInput>
{


    //public ExtendedController(/*EntityRepository<ExtendedComponent, Guid> repo, */ /*ExtendedService service, ExtendedFactory extendedFactory*/)// : base(/*repo,*/ /*service, extendedFactory*/)
    //{


    //}


    //ExtendedController(EntityRepository<ExtendedComponent, Guid> repo, ExtendedService service, ExtendedFactory extendedFactory) : base(repo, service, extendedFactory)
    //{


    //}

    public ExtendedController(IEntityRepository<ExtendedComponent, Guid> repo, IExtendedService<ExtendedCreateInput, ExtendedUpdateInput, ExtendedComponent, Guid> service, IComponentFactory<ExtendedComponent, ExtendedObject> extendedFactory) : base(repo, service, extendedFactory)
    {
        //var test = repo.FindByCondition(x => x.Where(y => true), false);

    }




    [HttpGet(Name = "GetExtended")]
    public async Task<IActionResult> Get(Guid id)
    {
        return await base.GetAsync(x => x.Where(y => y.Id == id));
    }

    [HttpGet(Name = "ListExtended")]
    public async Task<IActionResult> List(Guid id)
    {
        return await base.ListAsync(x => x.Where(y => true));
    }

    [HttpPut(Name = "UpdateExtended")]
    public async Task<IActionResult> Update(Guid id, ExtendedUpdateInput input)
    {
        return await base.UpdateAsync(id, input);
    }

    [HttpPost(Name = "PostExtended")]
    public async Task<IActionResult> Create(ExtendedCreateInput input) {
        return base.Create(input);
    }

}
