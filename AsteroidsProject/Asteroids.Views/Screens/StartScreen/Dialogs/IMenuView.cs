using System;
using Asteroids.Utility;

namespace Asteroids.Views.Screens.StartScreen.Dialogs
{
    public interface IMenuView : IDialog
    {
        public event Action<DialogType> OnShowDialog;
        public event Action OnPlay;
    }
}