using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Utility;

namespace Asteroids.Controllers.Main.Observers.GameObservers
{
    public class ShipHpPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly Timer _timer;

        public ShipHpPresenter(Environment environment)
        {
            _environment = environment;
            _timer = new Timer(20, true);
        }

        public void Attach()
        {
            _timer.OnNotify += AddHp;
            _environment.ShipData.OnDamage += Reset;
        }

        public void Detach()
        {
            _timer.OnNotify -= AddHp;
            _environment.ShipData.OnDamage -= Reset;
        }

        private void Reset(int obj)
        {
            _timer.Reset();
        }

        private void AddHp()
        {
            _environment.Screens.GameScreenData.Notify(ProgressIconType.Health);
        }
    }
}