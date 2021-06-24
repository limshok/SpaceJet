using System;
using Asteroids.Utility;

namespace Asteroids.Models.Screens.GameScreen
{
    public class GameScreenData: IData
    {
        public event Action<ProgressIconType> OnNotify;
        public event Action<ProgressIconType, int, int> OnSetProgressBarValue;
        public event Action<int> OnSetCoinCount;

        public event Action OnShow;
        public event Action OnHide;

        public void Notify(ProgressIconType obj)
        {
            OnNotify?.Invoke(obj);
        }

        public void Show()
        {
            OnShow?.Invoke();
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }

        public void SetProgressBarValue(ProgressIconType type, int value, int targetValue)
        {
            OnSetProgressBarValue?.Invoke(type, value, targetValue);
        }

        public void SetCoinCount(int obj)
        {
            OnSetCoinCount?.Invoke(obj);
        }
    }
}