using Asteroids.Core;
using Asteroids.Models.Screens.StartScreen.Dialogs;
using Asteroids.Utility;
using Asteroids.Views.Screens.StartScreen.Dialogs;

namespace Asteroids.Controllers.Screens.StartScreen.Dialogs
{
    public class ScoreboardDialogPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly ScoreboardData _data;
        private readonly IScoreboardView _view;

        public ScoreboardDialogPresenter(Environment environment,ScoreboardData data,IScoreboardView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }
        public void Attach()
        {
            _data.OnShow += _view.Show;
            _data.OnHide += Hide;
            _view.OnClose += Hide;
            _data.OnReloadScoreboard += ReloadScoreBoard;
            _data.MaxScoreList = _environment.SaveModel.GetList<int>("Scoreboard");
            ReloadScoreBoard();
            _view.Init();
        }

        public void Detach()
        {
            _view.Dispose();
            _data.OnShow -= _view.Show;
            _data.OnHide -= Hide;
            _data.OnReloadScoreboard -= ReloadScoreBoard;
        }

        private void ReloadScoreBoard()
        {
            _view.ReloadScoreboard(_data.MaxScoreList);
            _environment.SaveModel.Set("Scoreboard",_data.MaxScoreList);
        }

        private void Hide()
        {
            _view.Hide();
            _environment.Screens.StartScreenData.MenuData.Show();
        }
    }
}