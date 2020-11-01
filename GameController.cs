using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{

    public class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
            //Заполняем массив интерактивных объектов
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            
            //Переменные для сохранения данных
            var savedPlayerID = new DataSaver<Guid>
            {
                PlayerID = new Guid()
            };
            
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
    }

}