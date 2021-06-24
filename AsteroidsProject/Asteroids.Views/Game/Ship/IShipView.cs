using Asteroids.Utility;

namespace Asteroids.Views.Game.Ship
{
    public interface IShipView : IMovable
    {
        void Instance(ShipType type);
        void Destroy();
        void SetMaxHp(int hp);
        void SetCurrentHp(int hp);
    }
}