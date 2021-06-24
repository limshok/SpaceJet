using Asteroids.Core;
using Asteroids.Models.Screens.GameScreen;
using Asteroids.Utility;
using Asteroids.Views.Screens.GameScreen;

namespace Asteroids.Controllers.Screens.GameScreen
{
    public class GameScreenPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly GameScreenData _data;
        private readonly IGameScreenView _view;

        public GameScreenPresenter(Environment environment, GameScreenData data, IGameScreenView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _data.OnNotify += _view.ShowNotification;
            _data.OnShow += _view.Show;
            _data.OnHide += _view.Hide;
            _data.OnSetProgressBarValue += _view.SetProgressBarValue;
            _environment.GameScoreData.OnChangeScore += _view.ChangeScore;
        }

        public void Detach()
        {
            _data.OnNotify -= _view.ShowNotification;
            _data.OnShow -= _view.Show;
            _data.OnHide -= _view.Hide;
            _data.OnSetProgressBarValue -= _view.SetProgressBarValue;
            _environment.GameScoreData.OnChangeScore -= _view.ChangeScore;
        }
    }
}