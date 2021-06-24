using System;
using Asteroids.Views.Game.Asteroids;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace MonoViews
{
    public class SubAsteroidView : MonoBehaviour,ISubAsteroidView
    {

        public event Action<string> OnCollesion;

        public void SetPos(Vector2 pos)
        {
            transform.position = new Vector3(pos.X, transform.position.y, pos.Y);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OnCollisionEnter(Collision other)
        {
            OnCollesion?.Invoke(other.gameObject.tag);
        }

        public void SetPosition(Vector2 pos)
        {
            transform.position = new Vector3(pos.X, transform.position.y, pos.Y);
        }

        public Vector2 Move(float x, float y)
        {
            var vector = new Vector3(x * Time.deltaTime,0, -1 *y * Time.deltaTime);
            gameObject.transform.Translate(vector,Space.World);
            return new Vector2(transform.position.x, transform.position.z);
        }
    }
}