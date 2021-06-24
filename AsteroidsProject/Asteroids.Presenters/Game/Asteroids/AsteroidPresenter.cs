using System;
using System.Collections.Generic;
using System.Numerics;
using Asteroids.Core.Time;
using Asteroids.Models.Game.Asteroids;
using Asteroids.Utility;
using Asteroids.Views.Game.Asteroids;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Controllers.Game.Asteroids
{
    public class AsteroidPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly AsteroidData _data;
        private readonly IAsteroidView _view;
        private readonly List<SubAsteroidData> _removeModels = new List<SubAsteroidData>();
        private readonly Dictionary<SubAsteroidData, ISubAsteroidView> _views = new Dictionary<SubAsteroidData, ISubAsteroidView>();
        private readonly Dictionary<SubAsteroidData, DefaultAsteroidPresenter> _controllers = new Dictionary<SubAsteroidData, DefaultAsteroidPresenter>();
        private readonly Timer _spawnTimer;
        private readonly Random _random;


        public AsteroidPresenter(Environment environment, AsteroidData data, IAsteroidView view)
        {
            _random = new Random(DateTime.Now.Second * DateTime.Now.Minute);
            _environment = environment;
            _data = data;
            _view = view;
            _spawnTimer = new Timer(1 / _data.SpawnRate, true);
        }

        public void Attach()
        {
            _data.OnUpdate += Update;
            _data.OnDestroy += Destroy;
            _spawnTimer.OnNotify += Generate;
            _data.OnChangeAsteroidMaxHp += _view.SetAsteroidColor;
            _environment.GameDifficultyData.OnSetSpawnTime += _spawnTimer.ChangeTime;
            _environment.TimerCollection.Add(_spawnTimer);
            _data.ChangeAsteroidMaxHp(_environment.GameDifficultyData.StartHp);
        }

        public void Detach()
        {
            _data.OnUpdate -= Update;
            _data.OnDestroy -= Destroy;
            _spawnTimer.OnNotify -= Generate;
            _data.OnChangeAsteroidMaxHp -= _view.SetAsteroidColor;
            _environment.GameDifficultyData.OnSetSpawnTime -= _spawnTimer.ChangeTime;
            _environment.TimerCollection.Remove(_spawnTimer);
            Clear();
        }

        private void Update()
        {
            for (int i = 0; i < _data.GetModels().Count; i++)
            {
                var model = _data.GetModels()[i];
                if (model.Pos.X > _environment.GameLocationBoundaries.RightBoundary || model.Pos.X < _environment.GameLocationBoundaries.LeftBoundary || model.Pos.Y < _environment.GameLocationBoundaries.BottomBoundary || model.Pos.Y > _environment.GameLocationBoundaries.TopBoundary)
                {
                    _removeModels.Add(model);
                }
            }

            foreach (var removeModel in _removeModels)
            {
                Destroy(removeModel);
            }

            _removeModels.Clear();
        }

        private void Clear()
        {
            foreach (var controller in _controllers.Values)
            {
                controller.Detach();
            }

            _controllers.Clear();
            foreach (var view in _views)
            {
                _environment.AsteroidPullDictionary.GetPull(view.Key.Type, view.Key.Hp).Put(view.Value);
            }

            _views.Clear();
            _data.GetModels().Clear();
        }

        private void Destroy(SubAsteroidData data)
        {
            _controllers[data].Detach();
            _controllers.Remove(data);
            switch (data.Type)
            {
                case AsteroidType.Normal:
                    for (int i = 0; i < _data.NormalToSmall; i++)
                    {
                        Create(AsteroidType.Small, data.Pos, data.StartHp);
                    }

                    break;

                case AsteroidType.Huge:
                    for (int i = 0; i < _data.HugeToNormal; i++)
                    {
                        Create(AsteroidType.Normal, data.Pos, data.StartHp);
                    }

                    break;
            }

            _environment.AsteroidPullDictionary.GetPull(data.Type, data.StartHp).Put(_views[data]);
            _views.Remove(data);
            _data.Remove(data);
        }

        private void Create(AsteroidType type, Vector2 pos, int hp)
        {
            ISubAsteroidView view = _environment.AsteroidPullDictionary.GetPull(type, hp).Get();
            SubAsteroidData data = new SubAsteroidData(type, _data.Descriptions[type].Speed, hp, pos);
            var controller = new DefaultAsteroidPresenter(_environment, data, view);
            _data.Add(data);
            _views.Add(data, view);
            controller.Attach();
            _controllers.Add(data, controller);
        }

        private void CreateAtStart(AsteroidType type, int hp)
        {
            var startPos = new Vector2(_random.Next(_environment.GameLocationBoundaries.LeftBoundary, _environment.GameLocationBoundaries.RightBoundary), _environment.GameLocationBoundaries.TopBoundary);
            Create(type, startPos, hp);
        }

        private void Generate()
        {
            var hp = _environment.GameDifficultyData.GetHp();
            var chanceSum = 0;
            foreach (var description in _data.Descriptions.Values)
            {
                chanceSum += description.Chance;
            }

            var rndChance = _random.Next(chanceSum);
            if (rndChance < _data.Descriptions[AsteroidType.Small].Chance)
            {
                CreateAtStart(AsteroidType.Small, hp);
            }

            if (rndChance > _data.Descriptions[AsteroidType.Small].Chance && rndChance < _data.Descriptions[AsteroidType.Small].Chance + _data.Descriptions[AsteroidType.Normal].Chance)
            {
                CreateAtStart(AsteroidType.Normal, hp);
            }

            if (rndChance > _data.Descriptions[AsteroidType.Small].Chance + _data.Descriptions[AsteroidType.Normal].Chance && rndChance < chanceSum - _data.Descriptions[AsteroidType.Lava].Chance - _data.Descriptions[AsteroidType.Metal].Chance)
            {
                CreateAtStart(AsteroidType.Huge, hp);
            }

            if (rndChance > chanceSum - _data.Descriptions[AsteroidType.Lava].Chance - _data.Descriptions[AsteroidType.Metal].Chance && rndChance < chanceSum - _data.Descriptions[AsteroidType.Lava].Chance)
            {
                CreateAtStart(AsteroidType.Metal, hp);
            }

            if (rndChance > chanceSum - _data.Descriptions[AsteroidType.Lava].Chance && rndChance < chanceSum)
            {
                CreateAtStart(AsteroidType.Lava, hp);
            }
        }
    }
}