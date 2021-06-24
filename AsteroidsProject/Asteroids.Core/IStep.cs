using System.Collections.Generic;
using Asteroids.Utility;

namespace Asteroids.Core
{
    public interface IStep
    {
        void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView);
    }
}