using System;
using System.Numerics;
using Asteroids.Utility;

namespace Asteroid.Description
{
    [Serializable]
    public class ShipDescription
    {
        public ShipType Type;
        public int Hp;
        public float Speed;
        public int StartShotCount;
        public int StartDamage;
        public int Price;
        public Vector2 Position;
    }
}