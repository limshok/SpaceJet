using System;
using System.Collections.Generic;
using System.Numerics;
using Asteroid.Description;
using Asteroids.Utility;

namespace Asteroids.Models.Game.Ship
{
    public class ShipData: IData
    {
        public event Action<float, float> OnMove;
        public event Action<int> OnDamage;

        public Vector2 Position;
        private readonly List<ShipDescription> _shipDescriptions;
        public ShipDescription CurrentShipDescription;
        public int CurrentHp;
        public int MaxHp;


        public ShipData(List<ShipDescription> shipDescriptions)
        {
            _shipDescriptions = shipDescriptions;
        }

        public void Move(float x, float y)
        {
            OnMove?.Invoke(x, y);
        }

        public void Damage(int damage)
        {
            OnDamage?.Invoke(damage);
        }

        public void SetCurrentShip(ShipType type)
        {
            foreach (var shipDescription in _shipDescriptions)
            {
                if (shipDescription.Type == type)
                {
                    CurrentShipDescription = shipDescription;
                    break;
                }
            }
        }
    }
}