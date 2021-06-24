using System;

namespace Asteroids.Models.Main
{
    public class PlayerData: IData
    {
        public event Action<int> OnAddCoins;

        public int Coins;


       

        public void AddCoins(int obj)
        {
            Coins += obj;
            OnAddCoins?.Invoke(Coins);
        }
    }
}