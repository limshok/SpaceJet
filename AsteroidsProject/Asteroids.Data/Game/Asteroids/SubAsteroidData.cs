using System;
using System.Numerics;
using Asteroids.Utility;

namespace Asteroids.Models.Game.Asteroids
{
    public class SubAsteroidData: IData
    {
        public event Action OnUpdate;

        public readonly AsteroidType Type;
        public int Hp;
        public readonly int StartHp;
        public readonly float Speed;
        public Vector2 Direction;
        public Vector2 Pos;
        private readonly Random _random = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);

        public SubAsteroidData(AsteroidType type, float speed, int hp, Vector2 pos)
        {
            Type = type;
            Speed = speed;
            StartHp = hp;
            Pos = pos;
            float x = (_random.Next(100000) - 50000) / 100000f;
            Direction = new Vector2(x / 2, 1f);
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}