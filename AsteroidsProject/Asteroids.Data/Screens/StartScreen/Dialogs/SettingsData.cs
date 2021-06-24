using System;

namespace Asteroids.Models.Screens.StartScreen.Dialogs
{
    public class SettingsData : IDialogData
    {
        public event Action OnHide;
        public event Action OnShow;

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