using System;

namespace Asteroids.Models.Game.Score
{
    public class GameScoreData: IData
    {
        public event Action<int> OnChangeScore;
        
        public int Score;
        public int TimeScore;
        public int KillScore;
        public readonly int KillScoreMultiplier;
        public readonly int TimeScoreMultiplier;


        public GameScoreData(int timeScoreMultiplier, int killScoreMultiplier)
        {
            TimeScoreMultiplier = timeScoreMultiplier;
            KillScoreMultiplier = killScoreMultiplier;
        }


        public void ChangeScore()
        {
            Score = TimeScore + KillScore;
            OnChangeScore?.Invoke(Score);
        }

        public void Reset()
        {
            TimeScore = 0;
            KillScore = 0;
        }
    }
}