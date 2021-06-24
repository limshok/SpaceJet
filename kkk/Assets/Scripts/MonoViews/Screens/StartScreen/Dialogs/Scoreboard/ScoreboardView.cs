using System;
using System.Collections.Generic;
using Asteroids.Views.Screens.StartScreen.Dialogs;
using UnityEngine;
using UnityEngine.UI;

namespace MonoViews
{
    public class ScoreboardView : MonoBehaviour,IScoreboardView
    {
        public event Action OnClose;

        [SerializeField]private Button closeButton;
        [SerializeField]private GameObject prefab;
        [SerializeField]private Transform root;

        private List<GameObject> _scores = new List<GameObject>();
        public void ReloadScoreboard(List<int> scoreboardData)
        {
            foreach (var score in _scores)
            {
                Destroy(score);
            }
            _scores.Clear();
            for (int i = 0; i < scoreboardData.Count; i++)
            {
                var go = Instantiate(prefab, root);
                go.GetComponent<ScoreboardContainer>().SetScore(scoreboardData[scoreboardData.Count-i-1], i+1);    
                _scores.Add(go);
            }
        }

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
            closeButton.onClick.AddListener(() => { OnClose?.Invoke();});
        }

        public void Dispose()
        {
            closeButton.onClick.RemoveListener(() => { OnClose?.Invoke();});
        }
    }
}