using System;
using System.Collections.Generic;
using Asteroid.Description;
using Asteroids.Utility;
using Asteroids.Views.Screens.StartScreen.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class ShopView : MonoBehaviour, IShopView
    {
        public event Action OnBuy;
        public event Action OnSelect;
        public event Action OnHide;
        public event Action OnNext;
        public event Action OnPrevious;
        [Header("Buttons")]
        [SerializeField] private Button buy;
        [SerializeField] private Button select;
        [SerializeField] private Button next;
        [SerializeField] private Button previous;
        [SerializeField] private Button hide;
        
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Transform recordPlace;

        [SerializeField] private StatsContainer _statsContainer;
        [Header("Ships cant duplicate type!!!")]
        [SerializeField] private List<ShopContainer> _shopContainers;


        private GameObject  currentShip;

        public void SetCurrentShip(ShipDescription description, bool isPurchased, bool isInteractable, bool isSelected)
        {
            Destroy(currentShip);
            foreach (var shopContainer in _shopContainers)
            {
                if (shopContainer.Type == description.Type)
                {
                    currentShip = Instantiate(shopContainer.Prefab, recordPlace);
                    buy.interactable = isInteractable;
                    buy.gameObject.SetActive(!isPurchased);
                    select.gameObject.SetActive(isPurchased);
                    select.interactable = !isSelected;
                    priceText.gameObject.SetActive(!isPurchased);
                    priceText.text = description.Price.ToString();
                    _statsContainer.SetDamage(description.StartDamage,5);
                    _statsContainer.SetHp(description.Hp,5);
                    _statsContainer.SetSpeed(description.Speed,100);
                    _statsContainer.SetShotCount(description.StartShotCount,4);
                }
            }
        }

        public void Init()
        {
            buy.onClick.AddListener(() =>
            {
                OnBuy?.Invoke(); 
                buy.gameObject.SetActive(false);
                select.gameObject.SetActive(true);
                priceText.gameObject.SetActive(false);
            });
            hide.onClick.AddListener(() => { OnHide?.Invoke(); });
            select.onClick.AddListener(() =>
            {
                OnSelect?.Invoke(); 
                select.interactable = false;
            });
            next.onClick.AddListener(() => { OnNext?.Invoke(); });
            previous.onClick.AddListener(() => { OnPrevious?.Invoke(); });
        }

        public void Dispose()
        {
            hide.onClick.RemoveListener(() => { OnHide?.Invoke(); });
            buy.onClick.RemoveListener(() => { OnBuy?.Invoke(); });
            select.onClick.RemoveListener(() => { OnSelect?.Invoke(); });
            next.onClick.RemoveListener(() => { OnNext?.Invoke(); });
            previous.onClick.RemoveListener(() => { OnPrevious?.Invoke(); });
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}