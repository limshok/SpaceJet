using System;
using Asteroids.Views.Screens.StartScreen.Dialogs;
using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class SettingsView : MonoBehaviour,ISettingsView
    {
        public event Action OnHide;
        public event Action<int> OnJoystickType;
        public event Action<float> OnSoundVolume;
        public event Action<float> OnMusicVolume;

        [Header("Default")]
        [SerializeField] private Button Close;

        [Header("JoyStick Buttons")] 
        [SerializeField] private VariableJoystick Joystick;
        [SerializeField] private Button _dynamicJoystick;
        [SerializeField] private Button _floatingJoyStick;
        [SerializeField] private Button _fixedJoyStick;


        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Init()
        {
            Close.onClick.AddListener(() =>
            {
                OnHide?.Invoke();
                Debug.Log("HIDE ME SETTINGS");
            });
            _dynamicJoystick.onClick.AddListener(() => { Joystick.SetMode(JoystickType.Dynamic); });
            _floatingJoyStick.onClick.AddListener(() => { Joystick.SetMode(JoystickType.Floating); });
            _fixedJoyStick.onClick.AddListener(() => { Joystick.SetMode(JoystickType.Fixed); });
        }

        public void Dispose()
        {
            Close.onClick.RemoveListener(() => { OnHide?.Invoke();});
            _dynamicJoystick.onClick.RemoveListener(() => { Joystick.SetMode(JoystickType.Dynamic); });
            _floatingJoyStick.onClick.RemoveListener(() => { Joystick.SetMode(JoystickType.Floating); });
            _fixedJoyStick.onClick.RemoveListener(() => { Joystick.SetMode(JoystickType.Fixed); });
        }
    }
}