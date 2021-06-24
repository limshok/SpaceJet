using TMPro;
using UnityEngine;

namespace MonoViews
{
    public class ScoreboardContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _index;

        public void SetScore(int score,int index)
        {
            _index.text = index + ":";
            _scoreText.text = score.ToString();
        }
    }
}