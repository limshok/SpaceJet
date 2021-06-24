using System;
using Asteroids.Views.Game.Shots;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace DefaultNamespace.MonoViews
{
    public class SubShotView : MonoBehaviour,ISubShotView
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetPosition(Vector2 pos)
        {
            transform.position = new Vector3(pos.X, transform.position.y, pos.Y);
        }

        public Vector2 Move(float x, float y)
        {
            transform.Translate(x,y,0);
            return new Vector2(transform.position.x,transform.position.z);
        }

        public void SetRotation(int rotation)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,rotation,transform.rotation.eulerAngles.z);
        }

        public event Action<string> OnCollesion;

        private void OnCollisionEnter(Collision other)
        {
            OnCollesion?.Invoke(other.gameObject.tag);
        }
    }
}