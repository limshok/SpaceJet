using Asteroids.Core;
using Asteroids.Models.Screens.StartScreen;
using Asteroids.Utility;
using Asteroids.Views.Screens.StartScreen;

namespace Asteroids.Controllers.Screens.StartScreen
{
    public class StartScreenPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly StartScreenData _data;
        private readonly IStartScreenView _view;

        public StartScreenPresenter(Environment environment, StartScreenData data, IStartScreenView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _view.Init();
            _data.OnShow += _view.Show;
            _data.OnHide += _view.Hide;
            _environment.PlayerData.OnAddCoins += _view.SetCoinsCount;
        }

        public void Detach()
        {
            _view.Dispose();
            _data.OnShow -= _view.Show;
            _data.OnHide -= _view.Hide;
            _environment.PlayerData.OnAddCoins -= _view.SetCoinsCount;
        }
    }
}