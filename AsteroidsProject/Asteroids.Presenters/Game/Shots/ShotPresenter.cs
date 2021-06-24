using System.Collections.Generic;
using System.Numerics;
using Asteroids.Core;
using Asteroids.Core.Time;
using Asteroids.Models.Game.Shots;
using Asteroids.Utility;
using Asteroids.Views.Game.Shots;

namespace Asteroids.Controllers.Game.Shots
{
    public class ShotPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly ShotData _data;

        private readonly Dictionary<SubShotData, SubShotPresenter> _controllers = new Dictionary<SubShotData, SubShotPresenter>();
        private readonly Dictionary<SubShotData, ISubShotView> _views = new Dictionary<SubShotData, ISubShotView>();
        private readonly Timer _fireTimer;
        private Vector3 _fireType;

        public ShotPresenter(Environment environment, ShotData data)
        {
            _environment = environment;
            _data = data;
            _fireTimer = new Timer(1 / _data.FireRate, true);
        }

        public void Attach()
        {
            _data.ShotDamage = _environment.ShipData.CurrentShipDescription.StartDamage;
            _data.ShotCount = _environment.ShipData.CurrentShipDescription.StartShotCount;
            _fireTimer.OnNotify += Reload;
            _data.OnCreate += Create;
            _data.OnUpdate += Update;
            _environment.TimerCollection.Add(_fireTimer);
        }

        public void Detach()
        {
            _fireTimer.OnNotify -= Reload;
            _data.OnCreate -= Create;
            _environment.TimerCollection.Remove(_fireTimer);
            _data.OnUpdate -= Update; 
            Clear();
            Update();
        }


        private void Reload()
        {
            _data.IsReload = false;
        }

        private void Update()
        {
            foreach (var model in _data.RemoveList)
            {
                Destroy(model);
            }

            _data.RemoveList.Clear();


            foreach (var model in _data.SubShotModels)
            {
                if (model.Position.X > _environment.GameLocationBoundaries.RightBoundary || model.Position.X < _environment.GameLocationBoundaries.LeftBoundary || model.Position.Y < _environment.GameLocationBoundaries.BottomBoundary ||
                    model.Position.Y > _environment.GameLocationBoundaries.TopBoundary)
                {
                    if (!_data.RemoveList.Contains(model))
                    {
                        _data.RemoveList.Add(model);
                    }
                }
            }

            foreach (var model in _data.SubShotModels)
            {
                model.Update();
            }
        }

        private void Create()
        {
            var dataShotCount = _data.ShotCount / 3;
            _fireType = new Vector3(dataShotCount, dataShotCount + _data.ShotCount % 3, dataShotCount);


            if (!_data.IsReload)
            {
                _fireTimer.Reset();
                var models = new List<SubShotData>();
                for (int i = 0; i < _fireType.X; i++)
                {
                    models.Add(new SubShotData(new Vector2(_environment.ShipData.Position.X + (_fireType.X - 2 * i - 1) * 1.5f, _environment.ShipData.Position.Y), _data.ShotSpeed, 30, _data.ShotDamage));
                }

                for (int i = 0; i < _fireType.Y; i++)
                {
                    models.Add(new SubShotData(new Vector2(_environment.ShipData.Position.X + (_fireType.Y - 2 * i - 1) * 1.5f, _environment.ShipData.Position.Y), _data.ShotSpeed, 0, _data.ShotDamage));
                }

                for (int i = 0; i < _fireType.Z; i++)
                {
                    models.Add(new SubShotData(new Vector2(_environment.ShipData.Position.X + (_fireType.Z - 2 * i - 1) * 1.5f, _environment.ShipData.Position.Y), _data.ShotSpeed, -30, _data.ShotDamage));
                }

                foreach (var model in models)
                {
                    _data.SubShotModels.Add(model);
                    ISubShotView view = _environment.ShotPullDictionary.GetPull(model.MaxHp).Get();
                    _views.Add(model, view);
                    var controller = new SubShotPresenter(_environment, model, view);
                    controller.Attach();
                    _controllers.Add(model, controller);
                    _data.IsReload = true;
                }
            }
        }

        private void Destroy(SubShotData data)
        {
            _controllers[data].Detach();
            ISubShotView view = _views[data];
            _environment.ShotPullDictionary.GetPull(data.MaxHp).Put(view);
            _views.Remove(data);
            _controllers.Remove(data);
            _data.SubShotModels.Remove(data);
        }

        private void Clear()
        {
            foreach (var model in _data.SubShotModels)
            {
                if (!_data.RemoveList.Contains(model))
                {
                    _data.RemoveList.Add(model);
                }
            }
        }
    }
}