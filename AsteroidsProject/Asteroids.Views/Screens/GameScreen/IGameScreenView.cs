using Asteroids.Utility;

namespace Asteroids.Views.Screens.GameScreen
{
    public interface IGameScreenView : IScreenView
    {
        void ChangeScore(int obj);
        void ShowNotification(ProgressIconType type);
        void SetProgressBarValue(ProgressIconType type, int value, int targetValue);
    }
}