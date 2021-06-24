using System;
using Asteroids.Views.Game.Asteroids;
using UnityEngine;

namespace MonoViews
{
    public class AsteroidView  : MonoBehaviour,IAsteroidView
    {
        [SerializeField] private Material firstPoolAsteroidMaterial;
        [SerializeField] private Material secondPoolAsteroidMaterial;
        [SerializeField] private int CountOfColors;
        private float colorRange;
        private void Start()
        {
            colorRange = 1f / CountOfColors;
        } 

        public void SetAsteroidColor(int obj)
        {
            var color = Color.HSVToRGB(colorRange*(obj-1), 1, 0.1f, true);
            if (obj % 2 == 1)
            {
                firstPoolAsteroidMaterial.SetColor("_EmissionColor", color);
            }
            else
            {
                secondPoolAsteroidMaterial.SetColor("_EmissionColor", color);
            }
        }
    }
}