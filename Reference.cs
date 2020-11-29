using System.Collections;
using System.Collections.Generic;
using RollABall;
using UnityEngine;

public class Reference
{
    private PlayerBall _playerBall;
    private Camera _mainCamera;
    private GameObject _bonusScoreObj;
    private GameObject _gameOverObj;
    private Canvas _canvas;

    public PlayerBall PlayerBall
    {
        get
        {
            if (_playerBall == null)
            {
                var gameObject = Resources.Load<PlayerBall>("Player");
                _playerBall = Object.Instantiate(gameObject);
            }

            return _playerBall;
        }
    }

    public Camera MainCamera
    {
        get
        {
            if (_mainCamera == null)
            {
                _mainCamera = Camera.main;
            }

            return _mainCamera;
        }
    }
    
    
    public Canvas Canvas
    {
        get
        {
            if (_canvas == null)
            {
                _canvas = Object.FindObjectOfType<Canvas>();
            }
            return _canvas;
        }
    }
    
    public GameObject BonusScoreObj
    {
        get
        {
            if (_bonusScoreObj == null)
            {
                var gameObject = Resources.Load<GameObject>("UI/BonusScoreObj");
                _bonusScoreObj = Object.Instantiate(gameObject, Canvas.transform);
            }
            
            return _bonusScoreObj;
        }
    }

    public GameObject GameOverObj
    {
        get
        {
            if (_gameOverObj == null)
            {
                var gameObject = Resources.Load<GameObject>("UI/GameOverObj");
                _gameOverObj = Object.Instantiate(gameObject, Canvas.transform);
            }
            
            return _gameOverObj;
        }
    }
}
