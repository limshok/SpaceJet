using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Screens.StartScreen.Dialogs
{
    public class DialogsStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var menuPresenter = new MenuPresenter(environment, environment.Screens.StartScreenData.MenuData, environmentView.StartScreenView.MenuView);
            var shopPresenter = new ShopDialogPresenter(environment, environment.Screens.StartScreenData.ShopData, environmentView.StartScreenView.ShopView);
            var settingsPresenter = new SettingsDialogPresenter(environment, environment.Screens.StartScreenData.SettingsData, environmentView.StartScreenView.SettingsView);
            var scoreboardPresenter = new ScoreboardDialogPresenter(environment, environment.Screens.StartScreenData.ScoreboardData, environmentView.StartScreenView.ScoreboardView);
            controllers.Add(menuPresenter);
            controllers.Add(shopPresenter);
            controllers.Add(settingsPresenter);
            controllers.Add(scoreboardPresenter);
        }
    }
}