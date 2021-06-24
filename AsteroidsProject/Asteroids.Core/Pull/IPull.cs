using Asteroids.Views;

namespace Asteroids.Core.Pull
{
    public interface IPull<TComponent> where TComponent : IPullObject
    {
        void Init(IPullContainer<TComponent> container);
        void Dispose();
        TComponent Get();
        void Put(TComponent component);
    }
}