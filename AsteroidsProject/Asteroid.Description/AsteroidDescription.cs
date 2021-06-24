using System;
using System.Collections.Generic;

namespace Asteroid.Description
{
    [Serializable]
    public class AsteroidDescription
    {
        public int SpawnRate;
        public int NormalToSmall;
        public int HugeToNormal;
        public List<SubAsteroidDescription> AsteroidDescriptions;
    }
}