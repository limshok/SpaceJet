using System;

namespace Asteroids.Models.Screens.StartScreen
{
    public interface IDialogData: IData
    {
        event Action OnShow;
        event Action OnHide;
    }
}