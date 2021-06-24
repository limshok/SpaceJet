using Asteroids.Core;
using Asteroids.Utility;
using Asteroids.Views;

namespace Asteroids.Controllers.Game
{
    public class InputPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly IInputView _view;

        public InputPresenter(Environment environment, IInputView view)
        {
            _environment = environment;
            _view = view;
        }

        public void Attach()
        {
            _view.Move += Move;
            _view.Fire += Fire;
        }

        private void Fire()
        {
            _environment.ShotData.Create();
        }

        public void Detach()
        {
            _view.Move -= Move;
            _view.Fire -= Fire;
        }

        private void Move(float x, float y)
        {
            _environment.ShipData.Move(x, y);
        }
    }
}