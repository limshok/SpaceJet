using System;
using Asteroids.Utility;

namespace Asteroid.Description
{
    [Serializable]
    public class SubAsteroidDescription
    {
        public AsteroidType Type;
        public float Speed;
        public int Chance;
    }
}