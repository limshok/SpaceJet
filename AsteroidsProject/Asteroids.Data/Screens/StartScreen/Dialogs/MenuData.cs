using System;

namespace Asteroids.Models.Screens.StartScreen.Dialogs
{
    public class MenuData : IDialogData
    {
        public event Action OnShow;
        public event Action OnHide;

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