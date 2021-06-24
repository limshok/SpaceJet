using Asteroids.Core;
using Asteroids.Models.Screens.StartScreen.Dialogs;
using Asteroids.Utility;
using Asteroids.Views.Screens.StartScreen.Dialogs;

namespace Asteroids.Controllers.Screens.StartScreen.Dialogs
{
    public class MenuPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly MenuData _data;
        private readonly IMenuView _view;

        public MenuPresenter(Environment environment, MenuData data, IMenuView view)
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
            _view.OnPlay += Play;
            _view.OnShowDialog += ShowDialog;
        }

        public void Detach()
        {
            _view.Dispose();
            _data.OnShow -= _view.Show;
            _data.OnHide -= _view.Hide;
            _view.OnPlay -= Play;
            _view.OnShowDialog -= ShowDialog;
        }

        private void Play()
        {
            _environment.Screens.StartScreenData.Hide();
            _environment.GameManagerData.Start();
        }

        private void ShowDialog(DialogType obj)
        {
            _view.Hide();
            switch (obj)
            {
                case DialogType.Shop:
                    _environment.Screens.StartScreenData.ShopData.Show();
                    break;

                case DialogType.Settings:
                    _environment.Screens.StartScreenData.SettingsData.Show();
                    break;
                
                case DialogType.Scoreboard:
                    _environment.Screens.StartScreenData.ScoreboardData.Show();
                    break;
            }
        }
    }
}