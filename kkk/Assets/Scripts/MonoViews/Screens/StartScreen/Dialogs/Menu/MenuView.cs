using System;
using Asteroids.Utility;
using Asteroids.Views.Screens.StartScreen.Dialogs;
using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class MenuView : MonoBehaviour,IMenuView
    {
        public event Action<DialogType> OnShowDialog;

        public Button Play;
        public Button Shop;
        public Button Settings;
        public Button Scoreboard;
        
        public event Action OnPlay;

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
            Play.onClick.AddListener(() => { OnPlay?.Invoke(); });
            Shop.onClick.AddListener(() => { OnShowDialog?.Invoke(DialogType.Shop); });
            Settings.onClick.AddListener(() => { OnShowDialog?.Invoke(DialogType.Settings); });
            Scoreboard.onClick.AddListener(() => { OnShowDialog?.Invoke(DialogType.Scoreboard); });
        }

        public void Dispose()
        {
            Play.onClick.RemoveListener(() => { OnPlay?.Invoke(); });
            Shop.onClick.RemoveListener(() => { OnShowDialog?.Invoke(DialogType.Shop); });
            Settings.onClick.RemoveListener(() => { OnShowDialog?.Invoke(DialogType.Settings); });
            Scoreboard.onClick.RemoveListener(() => { OnShowDialog?.Invoke(DialogType.Scoreboard); });
        }
    }
}