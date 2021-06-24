using Asteroids.Views.Utility;

namespace Asteroids.Views.Screens
{
    public interface IScreenView : IGameObject
    {
        void Init();
        void Dispose();
    }
}