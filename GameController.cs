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
        private CameraController _cameraController;

        private void Awake()
        {
            //Заполняем массив интерактивных объектов
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            
            //Указываем, где выводится сообщение о проигрыше
            _gameOverDisplay = new GameOverDisplay(_gameOverLabel);
            
            //Пробегаемся по массиву интерактивных объектов, и если объект является BadBonus, добавляем методы к его делегату "Catch"

            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _gameOverDisplay.GameOver;
                } 
            }
            //Тоже самое с хорошими кубами
            foreach (var interactiveObject in _interactiveObjects)
            {
                if (interactiveObject is GoodBonus goodBonus)
                {
                    goodBonus.cameraShakeEvent += CameraShake;
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
            //Запускаем интерфейсы интерактивных объектов
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
        }
        
        private void CaughtPlayer(object catchingobject, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }
        
        //Тряска камеры
        private void CameraShake(object shaker)
        {
            _cameraController._offset += Vector3.down;
            Invoke("CameraOffsetUp", 0.5f);
            
            
        }

        private void CameraOffsetUp()
        {
            _cameraController._offset -= Vector3.down;
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
                }
            }
        }
    }

}