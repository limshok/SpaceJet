namespace Asteroids.Views
{
    public interface IPullContainer<TComponent> where TComponent : IPullObject
    {
        TComponent CreateObject();
        void DestroyObject(TComponent component);
        int GetStartCount();
    }
}