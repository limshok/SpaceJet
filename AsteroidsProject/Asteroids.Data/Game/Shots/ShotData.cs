using System;
using System.Collections.Generic;

namespace Asteroids.Models.Game.Shots
{
    public class ShotData: IData
    {
        public event Action OnCreate;
        public event Action OnUpdate;
        public event Action OnAddShotCount;
        public event Action<int> OnAddDamage;

        public bool IsReload;
        public readonly List<SubShotData> SubShotModels = new List<SubShotData>();
        public readonly List<SubShotData> RemoveList = new List<SubShotData>();
        public readonly float FireRate;
        public readonly float ShotSpeed;
        public int ShotDamage;
        public int ShotCount;


        public void AddShotCount()
        {
            ShotCount++;
            OnAddShotCount?.Invoke();
        }

        public ShotData(float fireRate, float shotSpeed)
        {
            FireRate = fireRate;
            ShotSpeed = shotSpeed;
        }

        public void Create()
        {
            OnCreate?.Invoke();
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }

        public void AddDamage()
        {
            ShotCount = 1;
            ShotDamage++;
            OnAddDamage?.Invoke(ShotDamage);
        }
    }
}