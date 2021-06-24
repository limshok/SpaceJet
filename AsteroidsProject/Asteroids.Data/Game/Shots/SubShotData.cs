using System;
using System.Numerics;

namespace Asteroids.Models.Game.Shots
{
    public class SubShotData : IData
    {
        public event Action OnMove;
        
        public readonly float Speed;
        public Vector2 Position;
        public readonly int Rotation;
        public int Hp;
        public readonly int MaxHp;
        
        public SubShotData(Vector2 position, float speed, int rotation, int hp)
        {
            Position = position;
            Speed = speed;
            Rotation = rotation;
            MaxHp = hp;
        }

        public void Update()
        {
            Move();
        }

        public void Move()
        {
            OnMove?.Invoke();
        }
    }
}