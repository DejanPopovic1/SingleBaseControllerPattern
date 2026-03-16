using  BestPractice.Database;
using BestPractice.Outputs;

namespace BestPractice.Factory
{
    public interface IComponentFactory<T, O> : IFactory where T: ComponentBase where O : BaseObject
    {
        O Make(T entity);
        List<O> MakeMany(IEnumerable<T> entities);
    }

    public interface IComponent2Factory<T, O> : IFactory where T : ComponentBase where O : BaseObject
    {
        O Make(T entity);
        List<O> MakeMany(IEnumerable<T> entities);
    }
}
