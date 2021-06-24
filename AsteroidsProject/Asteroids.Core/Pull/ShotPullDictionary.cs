using Asteroids.Core.Pull.Pulls;

namespace Asteroids.Core.Pull
{
    public class ShotPullDictionary : IPullDictionary<int, ShotsPull>
    {
        public readonly ShotsPull FirstShotsPull = new ShotsPull();
        public readonly ShotsPull SecondShotsPull = new ShotsPull();
        public readonly ShotsPull ThirdShotsPull = new ShotsPull();
        public readonly ShotsPull FourthShotsPull = new ShotsPull();
        public readonly ShotsPull FifthShotsPull = new ShotsPull();

        public ShotsPull GetPull(int index)
        {
            ShotsPull shotsPull = null;
            switch (index % 5)
            {
                case 0:
                    shotsPull = FifthShotsPull;
                    break;
                case 1:
                    shotsPull = FirstShotsPull;
                    break;
                case 2:
                    shotsPull = SecondShotsPull;
                    break;
                case 3:
                    shotsPull = ThirdShotsPull;
                    break;
                case 4:
                    shotsPull = FourthShotsPull;
                    break;
            }

            return shotsPull;
        }
    }
}