using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Models.Game.Score;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game.Score
{
    public class GameScorePresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly GameScoreData _data;
        private readonly Timer _timer;

        public GameScorePresenter(Environment environment, GameScoreData data)
        {
            _timer = new Timer(1, true);
            _environment = environment;
            _data = data;
        }

        public void Attach()
        {
            _data.Reset();
            _environment.AsteroidData.OnKill += AddKillScore;
            _timer.OnNotify += AddTimeScore;
            _environment.TimerCollection.Add(_timer);
        }

        public void Detach()
        {
            _environment.AsteroidData.OnKill -= AddKillScore;
            _timer.OnNotify -= AddTimeScore;
            _environment.TimerCollection.Remove(_timer);
            _environment.Screens.StartScreenData.ScoreboardData.AddScoreData(_data.Score);
        }


        private void AddTimeScore()
        {
            _data.TimeScore += _data.TimeScoreMultiplier;
            _data.ChangeScore();
        }

        private void AddKillScore(AsteroidType obj)
        {
            _data.KillScore += _data.KillScoreMultiplier;
            _data.ChangeScore();
        }
    }
}