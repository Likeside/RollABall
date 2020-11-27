using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{

    public class GameController : MonoBehaviour, IDisposable
    {
        public Text _gameOverLabel;
        private InteractiveObject[] _interactiveObjects;
        private GameOverDisplay _gameOverDisplay;
        private ScoreDisplay _scoreDisplay;
        private CameraController _cameraController;
        private ListOfExecutables _listOfExecutables;
        private int _pointsCollected;

        private void Awake()
        {
            _listOfExecutables = new ListOfExecutables();
            
            //Заполняем массив интерактивных объектов
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            
            //Инициализация сообщения о проигрыше
            _gameOverDisplay = new GameOverDisplay();
            
            //Инициализация сообщения о набранных очках
            _scoreDisplay = new ScoreDisplay();

            //Пробегаемся по массиву интерактивных объектов, и если объект является BadBonus, добавляем методы к его делегату "Catch"

            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _gameOverDisplay.GameOver;
                } 
            }
            //Тоже самое с хорошими кубами (тряска камеры и добавление очков)
            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is GoodBonus goodBonus)
                {
                    goodBonus.cameraShakeEvent += CameraShake;
                    goodBonus.OnPointsChanged += AddPoints;
                } 
            }
            
            //Переменные для сохранения данных
            var savedPlayerID = new DataSaver<Guid>
            {
                PlayerID = new Guid()
            };

            _cameraController = FindObjectOfType<CameraController>();

        }
        
        private void Update()
        {
            # region Запуск интерфейсов интерактивных объектов (перенесено в IExecute)
            /*
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlying iflying)
                {
                    iflying.Fly();
                }

                if (interactiveObject is IRotating irotating)
                {
                    irotating.Rotate();
                }

                if (interactiveObject is IFlickering iflickering)
                {
                    iflickering.Flicker();
                }
            }
            */
            #endregion


            for (var i = 0; i < _listOfExecutables.ListLength; i++)
            {
                var executalbeObject = _listOfExecutables[i];
                if (executalbeObject == null)
                {
                    continue;
                }
                executalbeObject.Execute();
            }
        }
        
        private void CaughtPlayer(object catchingobject, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }
        
        //Тряска камеры при подборе положительного бонуса
        private void CameraShake(object shaker)
        {
            _cameraController._offset += Vector3.down;
            Invoke("CameraOffsetUp", 0.5f);
            
            
        }
        private void CameraOffsetUp()
        {
            _cameraController._offset -= Vector3.down;
        }

        private void AddPoints(int points)
        {
            _pointsCollected += points;
            _scoreDisplay.Display(_pointsCollected);
        }
        
        //Диспоуз удаляет методы из списка делегата
        public void Dispose()
        {
            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is InteractiveObject _interactiveObjects)
                {
                    Destroy(interactiveObject.gameObject);
                    if (interactiveObject is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _gameOverDisplay.GameOver;
                    }

                    if (interactiveObject is GoodBonus goodBonus)
                    {
                        goodBonus.cameraShakeEvent -= CameraShake;
                        goodBonus.OnPointsChanged -= AddPoints;
                    }
                }
            }
        }
    }

}