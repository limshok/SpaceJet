using System;
using Asteroids.Views.Screens.StartScreen;
using Asteroids.Views.Screens.StartScreen.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class StartScreenView : MonoBehaviour, IStartScreenView
    {
        [SerializeField] private ShopView _shopView;
        [SerializeField] private MenuView _menuView;
        [SerializeField] private ScoreboardView _scoreboardView;
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private TextMeshProUGUI _coinsCount;

        public void Init()
        {
        }

        public void Dispose()
        {
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }


        public void SetCoinsCount(int count)
        {
            _coinsCount.text = count.ToString();
        }

        public IMenuView MenuView => _menuView;
        public IShopView ShopView => _shopView;
        public ISettingsView SettingsView => _settingsView;
        public IScoreboardView ScoreboardView => _scoreboardView;
    }
}