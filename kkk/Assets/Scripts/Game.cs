using System;
using System.Collections;
using System.Collections.Generic;
using Asteroid.Description;
using Asteroids;
using Asteroids.Core.Configs;
using DefaultNamespace;
using Descriptions;
using MonoViews;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameController _gameController ;

    [SerializeField] private EnvironmentComponent _environmentComponent;
    [SerializeField] private GameDescriptionSo _description;
    [SerializeField] private PullCollection PullCollection;
    private readonly SaveModel _saveModel = new SaveModel();
    private Configs configs;
    private void Awake()
    {
        _gameController = new GameController();
        configs = new Configs(_description.asteroidDescription,_description.shotDescription,_description.gameDifficultyDescription,_description.ShopDescription,_description.ScoreDescription);
        _gameController.Awake(_environmentComponent,_saveModel,configs);
    }


    void Start()
    {
    _gameController.Execute(_environmentComponent); 
    }

    void Update()
    {
        _gameController.Update(Time.deltaTime);
    }

    private void OnApplicationQuit()
    {
        _gameController.Clear();
    }
}
