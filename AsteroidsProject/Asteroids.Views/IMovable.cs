using System.Numerics;

namespace Asteroids.Views
{
    public interface IMovable
    {
        void SetPosition(Vector2 pos);
        Vector2 Move(float x, float y);
    }
}