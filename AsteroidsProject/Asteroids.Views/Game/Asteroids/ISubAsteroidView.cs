using System;

namespace Asteroids.Views.Game.Asteroids
{
    public interface ISubAsteroidView : IPullObject, IMovable
    {
        event Action<string> OnCollesion;
    }
}