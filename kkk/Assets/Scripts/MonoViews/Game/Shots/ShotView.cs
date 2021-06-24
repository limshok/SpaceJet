using Asteroids.Views.Game.Shots;
using UnityEngine;
using VolumetricLines;

namespace MonoViews
{
    public class ShotView : MonoBehaviour,IShotView
    {
        [SerializeField] private VolumetricLineBehavior ShotMaterial; 
        
        public void AddDamage(int obj)
        {
            ShotMaterial.LineColor = Color.magenta;
        }
    }
}