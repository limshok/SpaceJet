using Asteroids.Views.Game.Asteroids;
using UnityEngine;

namespace MonoViews
{
    public class GameLocationBoundaries : MonoBehaviour, IGameLocationBoundaries
    {
        private int _leftBoundary;
        private int _rightBoundary;
        private int _topBoundary;
        private int _bottomBoundary;
        public void Start()
        {
            _leftBoundary = (int) Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,Camera.main.transform.position.z -20)).x - 30;
            _rightBoundary = (int) Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z -20)).x + 30;
            _topBoundary = (int) Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,Camera.main.transform.position.z -20)).z + 100;
            _bottomBoundary = (int) Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.transform.position.z -20)).z;
        }

        public int TopBoundary =>_topBoundary;
        public int BottomBoundary =>_bottomBoundary;
        public int LeftBoundary =>_leftBoundary;
        public int RightBoundary =>_rightBoundary;
    }
}