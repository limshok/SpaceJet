using System;
using Asteroids.Core.Time;
using Asteroids.Models.Game.GameDifficulty;
using Asteroids.Utility;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Controllers.Game.GameDifficulty
{
    public class GameDifficultyPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly GameDifficultyData _data;
        private readonly Timer _timer;
        private int _time;

        public GameDifficultyPresenter(Environment environment, GameDifficultyData data)
        {
            _timer = new Timer(1, true);
            _environment = environment;
            _data = data;
        }

        public void Attach()
        {
            _environment.TimerCollection.Add(_timer);
            _environment.ShotData.OnAddDamage += RecalculateShipRating;
            _environment.ShotData.OnAddShotCount += RecalculateSpawnRating;
            _timer.OnNotify += timerOnNotify;
        }

        private void RecalculateSpawnRating()
        {
            var spawnRating = _environment.ShotData.FireRate * _environment.ShotData.ShotCount*_environment.ShotData.ShotDamage / (2 * _environment.AsteroidData.MaxHp) * _data.SpawnRatingMultiplier;
            if (spawnRating >= 10)
            {
                spawnRating = 10;
            }

            _data.SetSpawnRate(1 / spawnRating);
        }

        private void RecalculateShipRating(int obj)
        {
            _time++;
            _data.ShipRating = (_environment.ShotData.ShotDamage - 1) * 100 + _environment.ShipData.MaxHp * 30 + _time * 3;
            _environment.AsteroidData.ChangeAsteroidMaxHp((int) (Math.Truncate((_data.ShipRating + _data.AsteroidRatingSpan * _data.GameRatingSpanMultiplier) / _data.AsteroidRatingSpan) + _data.StartHp));
        }

        public void Detach()
        {
            _environment.TimerCollection.Remove(_timer);
            _environment.ShotData.OnAddDamage -= RecalculateShipRating;
            _environment.ShotData.OnAddShotCount -= RecalculateSpawnRating;
            _timer.OnNotify -= timerOnNotify;
        }

        private void timerOnNotify()
        {
            RecalculateShipRating(0);
        }
    }
}