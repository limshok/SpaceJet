using System;
using System.Collections.Generic;

namespace Asteroids.Models.Screens.StartScreen.Dialogs
{
    public class ScoreboardData : IDialogData
    {
        public event Action OnShow;
        public event Action OnHide;
        public event Action OnReloadScoreboard;

        public List<int> MaxScoreList = new List<int>();

        public void AddScoreData(int score)
        {
            MaxScoreList.Add(score);
            MaxScoreList.Sort();
            if (MaxScoreList.Count>10)
            {
                MaxScoreList.Remove(MaxScoreList[0]);
            }
            OnReloadScoreboard?.Invoke();
        }
        public void Hide()
        {
            OnHide?.Invoke();
        }

        public void Show()
        {
            OnShow?.Invoke();
        }
    }
}