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
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }
        
        private void Update()
        {
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