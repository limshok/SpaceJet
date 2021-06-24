using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Main.Observers.GameObservers
{
    public class ShotCountPresenter : IPresenter
    {
        private readonly Environment _environment;
        private int _referencedValue;
        private int _i;

        public ShotCountPresenter(Environment environment)
        {
            _environment = environment;
        }

        public void Attach()
        {
            _environment.Screens.GameScreenData.SetProgressBarValue(ProgressIconType.ShotCount, _i, 50 + _environment.ShotData.ShotCount * 10);
            _environment.AsteroidData.OnKill += AddCount;
            _referencedValue = _environment.ShotData.ShotCount;
        }

        public void Detach()
        {
            _environment.AsteroidData.OnKill -= AddCount;
            _environment.ShotData.ShotCount = _referencedValue;
        }

        private void AddCount(AsteroidType obj)
        {
            if (obj == AsteroidType.Small)
            {
                _i++;
                _environment.PlayerData.AddCoins(1);
                _environment.Screens.GameScreenData.SetProgressBarValue(ProgressIconType.ShotCount, _i, 50 + _environment.ShotData.ShotCount * 10);
                if (_i >= 50 + _environment.ShotData.ShotCount * 10)
                {
                    _environment.ShotData.AddShotCount();
                    _i = 0;
                }
            }
        }
    }
}