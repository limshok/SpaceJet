using Asteroids.Models.Screens.StartScreen.Dialogs;
using Asteroids.Utility;
using Asteroids.Views.Screens.StartScreen.Dialogs;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Controllers.Screens.StartScreen.Dialogs
{
    public class SettingsDialogPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly SettingsData _data;
        private readonly ISettingsView _view;

        public SettingsDialogPresenter(Environment environment, SettingsData data, ISettingsView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _view.OnHide += Hide;
            _data.OnHide += Hide;
            _data.OnShow += _view.Show;
            _view.Init();
        }

        public void Detach()
        {
            _view.Dispose();
            _view.OnHide -= Hide;
            _data.OnHide -= Hide;
            _data.OnShow -= _view.Show;
        }

        private void Hide()
        {
            _view.Hide();
            _environment.Screens.StartScreenData.MenuData.Show();
        }
    }
}