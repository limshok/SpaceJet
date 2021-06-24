using System;
using System.Collections.Generic;
using Asteroids.Views.Game.Shots;
using DefaultNamespace.MonoViews;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MonoViews
{
    
    [Serializable]
    public class ShotsPullContainer : IShotsPullContainer
    {
        [SerializeField] private int StartCount;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform root;
        private Dictionary<ISubShotView, GameObject> _gameObjects = new Dictionary<ISubShotView, GameObject>();

        public ISubShotView CreateObject()
        {
            var go = Object.Instantiate(prefab, root);
            var component = go.GetComponent<SubShotView>();
            _gameObjects.Add(component,go);
            return component;
        }

        public void DestroyObject(ISubShotView component)
        {
            Object.Instantiate(_gameObjects[component]);
            _gameObjects.Remove(component);
        }

        public int GetStartCount()
        {
            return StartCount;
        }
    }
}