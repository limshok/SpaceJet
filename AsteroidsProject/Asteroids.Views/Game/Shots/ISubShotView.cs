using System;

namespace Asteroids.Views.Game.Shots
{
    public interface ISubShotView : IPullObject, IMovable
    {
        event Action<string> OnCollesion;
        void SetRotation(int rotation);
    }
}