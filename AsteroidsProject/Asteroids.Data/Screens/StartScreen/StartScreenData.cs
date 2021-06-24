using System;
using System.Collections.Generic;
using Asteroid.Description;
using Asteroids.Models.Screens.StartScreen.Dialogs;

namespace Asteroids.Models.Screens.StartScreen
{
    public class StartScreenData: IData

    {
        public event Action OnShow;
        public event Action OnHide;
        public readonly MenuData MenuData = new MenuData();
        public readonly SettingsData SettingsData = new SettingsData();
        public readonly ScoreboardData ScoreboardData = new ScoreboardData();
        public readonly ShopData ShopData;


        public StartScreenData(ShopDescription description, List<int> purchasedShips)
        {
            ShopData = new ShopData(description, purchasedShips);
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