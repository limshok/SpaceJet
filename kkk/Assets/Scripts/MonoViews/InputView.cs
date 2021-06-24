using System;
using Asteroids.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class InputView : MonoBehaviour ,IInputView
    {
        public event Action<float, float> Move;
        public event Action Fire;
        
        
        private bool CameraPerspective = false;

        [SerializeField]private Joystick Joystick;
        [SerializeField]private NiceButton FireButton;
        [SerializeField]private Button SwitchCameraButton;
        [SerializeField]private TextMeshProUGUI SwitchCameraButtonText;
        [SerializeField]private Transform FirstCameraPosition;
        [SerializeField]private Transform SecondCameraPosition;
        [SerializeField] private GameObject Ship;

        private void Start()
        {
            FireButton.Notify += OnFire;
            SwitchCameraButton.onClick.AddListener(OnSwitchCameraButton);
        }

        private void OnSwitchCameraButton()
        {
            if (CameraPerspective)
            {
                Camera.main.transform.SetParent(FirstCameraPosition);
                SwitchCameraButtonText.text = "3D";
            }
            else
            {
                SwitchCameraButtonText.text = "2D";
                Camera.main.transform.SetParent(SecondCameraPosition);
            }
            Camera.main.transform.localPosition = Vector3.zero;
            Camera.main.transform.localRotation = Quaternion.identity;
            CameraPerspective = !CameraPerspective;
        } 
        void Update()
        {
                Ship.transform.rotation = new Quaternion(Ship.transform.rotation.x,Ship.transform.rotation.y,-Joystick.Horizontal/4,Ship.transform.rotation.w);
                    Move?.Invoke(Joystick.Horizontal,Joystick.Vertical);
        }

        private void OnFire()
        {
            Fire?.Invoke();
        }
    }
}