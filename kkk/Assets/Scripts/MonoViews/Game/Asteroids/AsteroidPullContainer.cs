using System;
using System.Collections.Generic;
using Asteroids.Views.Game.Asteroids;
using DefaultNamespace.MonoViews;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MonoViews
{
    [Serializable]
    public class AsteroidPullContainer : IAsteroidPullContainer
    {
        [SerializeField] private int StartCount;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform root;

        private Dictionary<ISubAsteroidView, GameObject> _gameObjects = new Dictionary<ISubAsteroidView, GameObject>();
        public ISubAsteroidView CreateObject()
        {
            var go = Object.Instantiate(prefab, root);
            var component = go.GetComponent<SubAsteroidView>();
            _gameObjects.Add(component,go);
            return component;
            
        }

        public void DestroyObject(ISubAsteroidView component)
        {
            Object.Destroy(_gameObjects[component]);
            _gameObjects.Remove(component);
        }

        public int GetStartCount()
        {
            return StartCount;
        }
    }
}