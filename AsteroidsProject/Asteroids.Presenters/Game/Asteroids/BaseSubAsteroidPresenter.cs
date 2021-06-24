using Asteroids.Core;
using Asteroids.Models.Game.Asteroids;
using Asteroids.Utility;
using Asteroids.Views.Game.Asteroids;

namespace Asteroids.Controllers.Game.Asteroids
{
    public abstract class BaseSubAsteroidPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly SubAsteroidData _data;
        private readonly ISubAsteroidView _view;

        protected BaseSubAsteroidPresenter(Environment environment, SubAsteroidData data, ISubAsteroidView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public virtual void Attach()
        {
            _data.Hp = _data.StartHp;
            _view.SetPosition(_data.Pos);
            _data.OnUpdate += Update;
            _view.OnCollesion += Collesion;
        }

        public virtual void Detach()
        {
            _data.OnUpdate -= Update;
            _view.OnCollesion -= Collesion;
        }

        private void Collesion(string obj)
        {
            switch (obj)
            {
                case "Asteroid":
                    break;
                case "Shot":
                    Damage(_environment.ShotData.ShotDamage);
                    break;
                case "Ship":
                    _environment.ShipData.Damage(1);
                    Damage(999);
                    break;
            }
        }

        protected virtual void Damage(int obj)
        {
            _data.Hp -= obj;
            if (_data.Hp <= 0)
            {
                _environment.AsteroidData.Destroy(_data);
                _environment.AsteroidData.Kill(_data.Type);
            }
        }

        private void Update()
        {
            _data.Pos = _view.Move(_data.Direction.X * _data.Speed, _data.Direction.Y * _data.Speed);
        }
    }
}