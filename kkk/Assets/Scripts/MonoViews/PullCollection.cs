using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Views.Game.Asteroids;
using Asteroids.Views.Game.Shots;
using DefaultNamespace.MonoViews;
using UnityEngine;

namespace MonoViews
{
    public class PullCollection: MonoBehaviour,IPullContainerCollection
    {
        [Header("Asteroid Pulls")]
        [SerializeField] private AsteroidPullContainer hugeFirstAsteroidPullContainer;
        [SerializeField] private AsteroidPullContainer normalFirstAsteroidPullContainer;
        [SerializeField] private AsteroidPullContainer smallFirstAsteroidPullContainer;
        [SerializeField] private AsteroidPullContainer hugeSecondAsteroidPullContainer;
        [SerializeField] private AsteroidPullContainer normalSecondAsteroidPullContainer;
        [SerializeField] private AsteroidPullContainer smallSecondAsteroidPullContainer;
        
        [SerializeField] private AsteroidPullContainer metalAsteroidPullContainer;
        [SerializeField] private AsteroidPullContainer lavaAsteroidPullContainer;
        
        [Header("Shots Pulls")]
        [SerializeField] private List<ShotsPullContainer> ShotsPullContainers;

        public IAsteroidPullContainer HugeSecondAsteroidPullContainer => hugeSecondAsteroidPullContainer;
        public IAsteroidPullContainer NormalSecondAsteroidPullContainer => normalSecondAsteroidPullContainer;
        public IAsteroidPullContainer SmallSecondAsteroidPullContainer => smallSecondAsteroidPullContainer;
        public IAsteroidPullContainer HugeFirstAsteroidPullContainer => hugeFirstAsteroidPullContainer;
        public IAsteroidPullContainer NormalFirstAsteroidPullContainer => normalFirstAsteroidPullContainer;
        public IAsteroidPullContainer SmallFirstAsteroidPullContainer => smallFirstAsteroidPullContainer;

        public IAsteroidPullContainer MetalAsteroidPullContainer => metalAsteroidPullContainer;
        public IAsteroidPullContainer LavaAsteroidPullContainer => lavaAsteroidPullContainer;
        
        public IShotsPullContainer FirstShotsPullContainer => ShotsPullContainers[0];
        public IShotsPullContainer SecondShotsPullContainer => ShotsPullContainers[1];
        public IShotsPullContainer ThirdShotsPullContainer => ShotsPullContainers[2];
        public IShotsPullContainer FourthShotsPullContainer => ShotsPullContainers[3];
        public IShotsPullContainer FifthShotsPullContainer => ShotsPullContainers[4];
    }
}