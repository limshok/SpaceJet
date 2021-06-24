using System;
using System.Collections.Generic;
using Asteroid.Description;
using Asteroids.Utility;

namespace Asteroids.Models.Game.Asteroids
{
    public class AsteroidData : IData
    {
        public event Action<SubAsteroidData> OnDestroy;
        public event Action OnUpdate;
        public event Action<AsteroidType> OnKill;
        public event Action<int> OnChangeAsteroidMaxHp;
        
        private readonly List<SubAsteroidData> _subModels = new List<SubAsteroidData>();
        public readonly Dictionary<AsteroidType, SubAsteroidDescription> Descriptions = new Dictionary<AsteroidType, SubAsteroidDescription>();
        public readonly float SpawnRate;
        public readonly int HugeToNormal;
        public readonly int NormalToSmall;
        public int MaxHp;

        public AsteroidData(List<SubAsteroidDescription> subAsteroidDescriptions, int hugeToNormal, int normalToSmall, float spawnRate)
        {
            SpawnRate = spawnRate;
            HugeToNormal = hugeToNormal;
            NormalToSmall = normalToSmall;
            foreach (var subAsteroidDescription in subAsteroidDescriptions)
            {
                Descriptions.Add(subAsteroidDescription.Type, subAsteroidDescription);
            }
        }

        public void Update()
        {
            OnUpdate?.Invoke();
            foreach (var subModel in _subModels)
            {
                subModel.Update();
            }
        }

        public void Add(SubAsteroidData data)
        {
            _subModels.Add(data);
        }

        public void Remove(SubAsteroidData data)
        {
            _subModels.Remove(data);
        }

        public void Destroy(SubAsteroidData data)
        {
            OnDestroy?.Invoke(data);
        }

        public List<SubAsteroidData> GetModels()
        {
            return _subModels;
        }

        public void Kill(AsteroidType obj)
        {
            OnKill?.Invoke(obj);
        }

        public void ChangeAsteroidMaxHp(int maxHp)
        {
            MaxHp = maxHp;
            OnChangeAsteroidMaxHp?.Invoke(maxHp);
        }
    }
}