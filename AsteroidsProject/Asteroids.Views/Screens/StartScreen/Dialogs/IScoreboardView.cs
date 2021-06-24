using System;
using System.Collections.Generic;

namespace Asteroids.Views.Screens.StartScreen.Dialogs
{
    public interface IScoreboardView:IDialog
    {
        event Action OnClose;
        void ReloadScoreboard(List<int> scoreboardData);
    }
}