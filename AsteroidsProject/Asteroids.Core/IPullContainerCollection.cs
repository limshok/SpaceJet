using Asteroids.Views.Game.Asteroids;
using Asteroids.Views.Game.Shots;

namespace Asteroids.Core
{
    public interface IPullContainerCollection
    {
        public IAsteroidPullContainer SmallSecondAsteroidPullContainer { get; }
        public IAsteroidPullContainer NormalSecondAsteroidPullContainer { get; }
        public IAsteroidPullContainer HugeSecondAsteroidPullContainer { get; }
        public IAsteroidPullContainer SmallFirstAsteroidPullContainer { get; }
        public IAsteroidPullContainer NormalFirstAsteroidPullContainer { get; }
        public IAsteroidPullContainer HugeFirstAsteroidPullContainer { get; }
        public IAsteroidPullContainer MetalAsteroidPullContainer { get; }
        public IAsteroidPullContainer LavaAsteroidPullContainer { get; }
        public IShotsPullContainer FirstShotsPullContainer { get; }
        public IShotsPullContainer SecondShotsPullContainer { get; }
        public IShotsPullContainer ThirdShotsPullContainer { get; }
        public IShotsPullContainer FourthShotsPullContainer { get; }
        public IShotsPullContainer FifthShotsPullContainer { get; }
    }
}