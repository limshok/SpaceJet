using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Main.Observers.GameObservers
{
    public class ShotDamagePresenter : IPresenter
    {
        private readonly Environment _environment;
        private int _referencedValue;

        public ShotDamagePresenter(Environment environment)
        {
            _environment = environment;
        }

        public void Attach()
        {
            _environment.Screens.GameScreenData.SetProgressBarValue(ProgressIconType.Damage, _environment.ShotData.ShotCount, 3 + _environment.ShotData.ShotDamage);
            _environment.ShotData.OnAddShotCount += AddDamage;
            _referencedValue = _environment.ShotData.ShotDamage;
        }

        private void AddDamage()
        {
            _environment.Screens.GameScreenData.SetProgressBarValue(ProgressIconType.Damage, _environment.ShotData.ShotCount, 3 + _environment.ShotData.ShotDamage);
            if (_environment.ShotData.ShotCount == 3 + _environment.ShotData.ShotDamage)
            {
                _environment.ShotData.AddDamage();
            }
        }

        public void Detach()
        {
            _environment.ShotData.OnAddShotCount -= AddDamage;
            _environment.ShotData.ShotDamage = _referencedValue;
        }
    }
}