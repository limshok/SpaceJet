namespace Asteroids.Views.Game.Asteroids
{
    public interface IGameLocationBoundaries
    {
        int TopBoundary { get; }
        int BottomBoundary { get; }
        int LeftBoundary { get; }
        int RightBoundary { get; }
    }
}