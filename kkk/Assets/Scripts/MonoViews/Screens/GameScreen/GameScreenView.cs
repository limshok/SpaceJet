using Asteroids.Models.Screens.GameScreen;
using Asteroids.Utility;
using Asteroids.Views.Screens.GameScreen;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class GameScreenView : MonoBehaviour, IGameScreenView
    {
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TextMeshProUGUI targetText;
        [SerializeField] private TextMeshProUGUI _score;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ChangeScore(int obj)
        {
            _score.text = obj.ToString();
        }

        public void ShowNotification(ProgressIconType type)
        {
        }

        public void Init()
        {
        }

        public void Dispose()
        {
        }

        public void SetProgressBarValue(ProgressIconType type, int value, int targetValue)
        {
            switch (type)
            {
                case ProgressIconType.ShotCount:
                    _progressBar.maxValue = targetValue;
                    _progressBar.value = value;
                    break;
                case ProgressIconType.Damage:
                    if (value == (targetValue - 1))
                    {
                        targetText.text = "damage+";
                    }
                    else
                    {
                        targetText.text = "shot+";
                    }
                    break;
            }
        }
    }
}