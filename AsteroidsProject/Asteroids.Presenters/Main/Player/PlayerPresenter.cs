using Asteroids.Models.Main;
using Asteroids.Utility;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Controllers.Main.Player
{
    public class PlayerPresenter : IPresenter
    {
        private readonly Environment _environment;
        private readonly PlayerData _data;


        public PlayerPresenter(Environment environment, PlayerData data)
        {
            _environment = environment;
            _data = data;
        }

        public void Attach()
        {
            _environment.PlayerData.AddCoins(_environment.SaveModel.Get<int>("coins"));
            _environment.PlayerData.OnAddCoins += SaveCoins;
        }

        public void Detach()
        {
            _environment.PlayerData.OnAddCoins -= SaveCoins;
        }

        private void SaveCoins(int obj)
        {
            _environment.SaveModel.Set("coins", obj);
        }
    }
}