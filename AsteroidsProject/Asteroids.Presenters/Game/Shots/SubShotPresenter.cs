using Asteroids.Core;
using Asteroids.Models.Game.Shots;
using Asteroids.Utility;
using Asteroids.Views.Game.Shots;

namespace Asteroids.Controllers.Game.Shots
{
    public class SubShotPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly SubShotData _data;
        private readonly ISubShotView _view;


        public SubShotPresenter(Environment environment, SubShotData data, ISubShotView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _data.OnMove += Move;
            _view.OnCollesion += Collesion;
            _view.SetPosition(_data.Position);
            _view.SetRotation(_data.Rotation);
            _data.Hp = _data.MaxHp;
        }

        private void Collesion(string obj)
        {
            switch (obj)
            {
                case "Asteroid":
                    _data.Hp -= _environment.AsteroidData.MaxHp;
                    if (_data.Hp <= 0)
                    {
                        Destroy();
                    }

                    break;
            }
        }

        private void Destroy()
        {
            _view.Hide();
            if (!_environment.ShotData.RemoveList.Contains(_data))
            {
                _environment.ShotData.RemoveList.Add(_data);
            }
        }


        public void Detach()
        {
            _data.OnMove -= Move;
            _view.OnCollesion -= Collesion;
        }

        private void Move()
        {
            _data.Position = _view.Move(0, _data.Speed);
        }
    }
}