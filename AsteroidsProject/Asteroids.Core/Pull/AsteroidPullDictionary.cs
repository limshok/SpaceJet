using Asteroids.Core.Pull.Pulls;
using Asteroids.Utility;

namespace Asteroids.Core.Pull
{
    public class AsteroidPullDictionary : IPullDictionary<AsteroidType, int, AsteroidPull>
    {
        public readonly AsteroidPull HugeFirstAsteroidsPull = new AsteroidPull();
        public readonly AsteroidPull NormalFirstAsteroidsPull = new AsteroidPull();
        public readonly AsteroidPull SmallFirstAsteroidsPull = new AsteroidPull();
        public readonly AsteroidPull HugeSecondAsteroidsPull = new AsteroidPull();
        public readonly AsteroidPull NormalSecondAsteroidsPull = new AsteroidPull();
        public readonly AsteroidPull SmallSecondAsteroidsPull = new AsteroidPull();
        public readonly AsteroidPull MetalAsteroidPull = new AsteroidPull();
        public readonly AsteroidPull LavaAsteroidPull = new AsteroidPull();

        public AsteroidPull GetPull(AsteroidType indexA, int indexB)
        {
            AsteroidPull asteroidPull = null;
            switch (indexA)
            {
                case AsteroidType.Small:
                    asteroidPull = indexB % 2 == 1 ? SmallFirstAsteroidsPull : SmallSecondAsteroidsPull;

                    break;
                case AsteroidType.Normal:
                    asteroidPull = indexB % 2 == 1 ? NormalFirstAsteroidsPull : NormalSecondAsteroidsPull;

                    break;

                case AsteroidType.Huge:
                    asteroidPull = indexB % 2 == 1 ? HugeFirstAsteroidsPull : HugeSecondAsteroidsPull;

                    break;
                case AsteroidType.Metal:
                    asteroidPull = MetalAsteroidPull;
                    break;
                case AsteroidType.Lava:
                    asteroidPull = LavaAsteroidPull;
                    break;
            }

            return asteroidPull;
        }
    }
}