using System;
using System.Collections.Generic;
using System.Drawing;
using Asteroids.Utility;
using Asteroids.Views.Game.Ship;
using MonoViews;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = System.Numerics.Vector2;

namespace DefaultNamespace.MonoViews
{
    public class ShipView : MonoBehaviour, IShipView
    {
        [SerializeField] private Slider HpBar;
        [SerializeField] private Transform ThirdPersonCameraRoot;
        [SerializeField] private List<ShopContainer> _shopContainers;
        [SerializeField] private Transform ShipRoot;
        private GameObject ship;
        private Vector3 _higherScreenBoundary;
        private Vector3 _lowerScreenBoundary;

        private void Start()
        {
            var zDif = Camera.main.transform.position.z - 25;
            _higherScreenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, zDif));
            _lowerScreenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, zDif));
        }

        public void SetPosition(Vector2 pos)
        {
            transform.localPosition = new Vector3(pos.X, transform.localPosition.y, pos.Y);
            ThirdPersonCameraRoot.localPosition = new Vector3(pos.X, ThirdPersonCameraRoot.localPosition.y, pos.Y);
                
        }

        public Vector2 Move(float x, float y)
        {
            ship.GetComponent<TrailsAnimator>().AnimateTrails(0.6f + (y+50)/250  );
            var yDelta = y*Time.deltaTime;
            var xDelta = x*Time.deltaTime;
            if (Math.Abs(transform.position.x - ThirdPersonCameraRoot.position.x) < 1)
            {
                if (!(ThirdPersonCameraRoot.position.x + xDelta < _lowerScreenBoundary.x+10 || ThirdPersonCameraRoot.position.x + xDelta >  _higherScreenBoundary.x-10))
                {
                    ThirdPersonCameraRoot.Translate(xDelta,0,0);
                }
            }
            if (!(ThirdPersonCameraRoot.position.z + yDelta < _lowerScreenBoundary.z || ThirdPersonCameraRoot.position.z + yDelta > _higherScreenBoundary.z))
            {
                ThirdPersonCameraRoot.Translate(0, 0, y * Time.deltaTime);
            }    
            
            if (!(transform.position.x + xDelta < _lowerScreenBoundary.x|| transform.position.x + xDelta> _higherScreenBoundary.x ))
            {
                transform.Translate(x* Time.deltaTime, 0, 0 );
            }

            if (!(transform.position.z + yDelta < _lowerScreenBoundary.z || transform.position.z + yDelta > _higherScreenBoundary.z))
            {
                transform.Translate(0, 0, y * Time.deltaTime);
            }
            
            return new Vector2(transform.position.x, transform.position.z);
        }

        public void Instance(ShipType type)
        {
            foreach (var shopContainer in _shopContainers)
            {
                if (shopContainer.Type == type)
                {
                    ship = Instantiate(shopContainer.Prefab,ShipRoot);
                }
            }
        }

        public void Destroy()
        {
            Destroy(ship);
        }

        public void SetMaxHp(int hp)
        {
            HpBar.maxValue = hp;
            HpBar.value = hp;
        }

        public void SetCurrentHp(int hp)
        {
            HpBar.value = hp;
        }
    }
}