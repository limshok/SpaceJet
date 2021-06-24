using Asteroids.Views.Screens.StartScreen.Dialogs;

namespace Asteroids.Views.Screens.StartScreen
{
    public interface IStartScreenView : IScreenView
    {
        void SetCoinsCount(int count);
        IMenuView MenuView { get; }
        IShopView ShopView { get; }
        ISettingsView SettingsView { get; }
        IScoreboardView ScoreboardView { get; }
    }
}