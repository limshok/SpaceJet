using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Main.Observers.GameObservers
{
    public class GameObserverPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly List<IPresenter> _observers = new List<IPresenter>();

        public GameObserverPresenter(Environment environment)
        {
            _environment = environment;
        }

        public void Attach()
        {
            _observers.Add(new ShotCountPresenter(_environment));
            _observers.Add(new ShipHpPresenter(_environment));
            _observers.Add(new ShotDamagePresenter(_environment));
            foreach (var observerController in _observers)
            {
                observerController.Attach();
            }
        }

        public void Detach()
        {
            foreach (var observerController in _observers)
            {
                observerController.Detach();
            }

            _observers.Clear();
        }
    }
}