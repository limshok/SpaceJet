using System;
using System.Collections.Generic;
using Asteroid.Description;

namespace Asteroids.Models.Screens.StartScreen.Dialogs
{
    public class ShopData : IDialogData
    {
        public event Action OnShow;
        public event Action OnHide;

        public readonly List<ShopUnitData> ShopUnitDatas = new List<ShopUnitData>();

        public ShopData(ShopDescription shopDescription, List<int> purchasedShips)
        {
            foreach (var shipDescription in shopDescription.ShipDescriptions)
            {
                ShopUnitDatas.Add(new ShopUnitData(shipDescription, purchasedShips.Contains((int) shipDescription.Type)));
            }
        }

        public void Show()
        {
            OnShow?.Invoke();
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }
    }
}