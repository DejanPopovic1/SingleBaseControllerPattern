using BestPractice.Database;
using BestPractice.Outputs;

namespace BestPractice.Factory;

public class ExtendedFactory : IComponentFactory<ExtendedComponent, ExtendedObject>
{
    public ExtendedObject Make(ExtendedComponent component)
    {
        return new ExtendedObject()
        {
            test1 = component.test1,
            test2 = component.test2,
            test3 = component.test3
        };
    }

    public List<ExtendedObject> MakeMany(IEnumerable<ExtendedComponent> components)
    {
        return components.Select(x =>
        {
            return new ExtendedObject()
            {
                test1 = x.test1,
                test2 = x.test2,
                test3 = x.test3
            };
        }).ToList();
    }
}
