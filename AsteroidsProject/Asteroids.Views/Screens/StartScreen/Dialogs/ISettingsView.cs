using System;

namespace Asteroids.Views.Screens.StartScreen.Dialogs
{
    public interface ISettingsView : IDialog
    {
        public event Action OnHide;
        public event Action<int> OnJoystickType;
        public event Action<float> OnSoundVolume;
        public event Action<float> OnMusicVolume;
    }
}