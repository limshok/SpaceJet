using System.Collections.Generic;
using Asteroids.Models.Screens.StartScreen.Dialogs;
using Asteroids.Utility;
using Asteroids.Views.Screens.StartScreen.Dialogs;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Controllers.Screens.StartScreen.Dialogs
{
    public class ShopDialogPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly ShopData _data;
        private readonly IShopView _view;
        private int _currentIndex;

        public ShopDialogPresenter(Environment environment, ShopData data, IShopView view)
        {
            _environment = environment;
            _data = data;
            _view = view;
        }

        public void Attach()
        {
            _view.Init();
            _data.OnShow += _view.Show;
            _view.OnHide += Hide;
            _view.OnSelect += Select;
            _view.OnBuy += Buy;
            _view.OnNext += Next;
            _view.OnPrevious += Previous;
            SetCurrentShip(_currentIndex);
            _environment.ShipData.SetCurrentShip(_environment.SaveModel.Get<ShipType>("currentShip"));
        }

        public void Detach()
        {
            _view.Dispose();
            _data.OnShow -= _view.Show;
            _data.OnHide -= _view.Hide;
            _view.OnBuy -= Buy;
            _view.OnNext -= Next;
            _view.OnPrevious -= Previous;
        }

        private void Select()
        {
            _environment.ShipData.SetCurrentShip(_data.ShopUnitDatas[_currentIndex].Description.Type);
            _environment.SaveModel.Set("currentShip",_data.ShopUnitDatas[_currentIndex].Description.Type);
        }

        private void Hide()
        {
            _view.Hide();
            _environment.Screens.StartScreenData.MenuData.Show();
        }

        private void Next()
        {
            if (_currentIndex != _data.ShopUnitDatas.Count - 1)
            {
                _currentIndex++;
            }
            else
            {
                _currentIndex = 0;
            }

            SetCurrentShip(_currentIndex);
        }

        private void Previous()
        {
            if (_currentIndex != 0)
            {
                _currentIndex--;
            }
            else
            {
                _currentIndex = _data.ShopUnitDatas.Count - 1;
            }

            SetCurrentShip(_currentIndex);
        }

        private void SetCurrentShip(int index)
        {
            var shopUnitData = _data.ShopUnitDatas[index];
            _view.SetCurrentShip(shopUnitData.Description, shopUnitData.IsPurchased, _environment.PlayerData.Coins >= shopUnitData.Description.Price, _environment.ShipData.CurrentShipDescription == shopUnitData.Description);
            
        }

        private void Buy()
        {
            _data.ShopUnitDatas[_currentIndex].IsPurchased = true;
            _environment.PlayerData.AddCoins(-_data.ShopUnitDatas[_currentIndex].Description.Price);
            List<int> purchasedList = new List<int>();
            foreach (var shopUnitData in _data.ShopUnitDatas)
            {
                if (shopUnitData.IsPurchased)
                {
                    purchasedList.Add((int) shopUnitData.Description.Type);
                }
            }

            _environment.SaveModel.Set("purchasedShips", purchasedList);
        }
    }
}