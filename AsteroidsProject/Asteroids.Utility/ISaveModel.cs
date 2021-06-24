using System.Collections.Generic;

namespace Asteroids.Utility
{
    public interface ISaveModel
    {
        public void Set<T>(string key, T value);

        public T Get<T>(string key);

        public List<T> GetList<T>(string key);
    }
}