using System.Numerics;
using Asteroids.Models.Game.Ship;
using Asteroids.Utility;
using Asteroids.Views.Game.Ship;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Controllers.Game.Ship
{
    public class ShipPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly ShipData _data;
        private readonly IShipView _view;

        public ShipPresenter(Environment environment, ShipData data, IShipView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _view.Instance(_data.CurrentShipDescription.Type);
            _data.OnMove += Move;
            _data.OnDamage += Damage;
            _view.SetMaxHp(_data.CurrentShipDescription.Hp);
            _data.MaxHp = _data.CurrentShipDescription.Hp;
            _data.CurrentHp = _data.MaxHp;
            _view.SetPosition(new Vector2(0, 0));
        }

        public void Detach()
        {
            _view.Destroy();
            _data.OnMove -= Move;
            _data.OnDamage -= Damage;
        }

        private void Damage(int dmg)
        {
            _data.CurrentHp -= dmg;
            _view.SetCurrentHp(_data.CurrentHp);
            if (_data.CurrentHp <= 0)
            {
                _environment.GameManagerData.Stop();
            }
        }

        private void Move(float x, float y)
        {
            _data.Position = _view.Move(x * _data.CurrentShipDescription.Speed, y * _data.CurrentShipDescription.Speed);
        }
    }
}