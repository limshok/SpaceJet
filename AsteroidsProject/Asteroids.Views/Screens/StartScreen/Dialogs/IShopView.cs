using System;
using Asteroid.Description;
using Asteroids.Utility;

namespace Asteroids.Views.Screens.StartScreen.Dialogs
{
    public interface IShopView : IDialog
    {
        event Action OnBuy;
        event Action OnSelect;
        event Action OnHide;
        event Action OnNext;
        event Action OnPrevious;

        void SetCurrentShip(ShipDescription description, bool isPurchased, bool isInteractable, bool isSelected);
    }
}