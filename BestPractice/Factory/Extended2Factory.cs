using BestPractice.Database;
using BestPractice.Outputs;

namespace BestPractice.Factory;

public class Extended2Factory : IComponent2Factory<Extended2Component, Extended2Object>
{
    public Extended2Object Make(Extended2Component component)
    {
        return new Extended2Object()
        {
            test1 = component.test1,
            test2 = component.test2,
            test3 = component.test3
        };
    }

    public List<Extended2Object> MakeMany(IEnumerable<Extended2Component> components)
    {
        return components.Select(x =>
        {
            return new Extended2Object()
            {
                test1 = x.test1,
                test2 = x.test2,
                test3 = x.test3
            };
        }).ToList();
    }
}
