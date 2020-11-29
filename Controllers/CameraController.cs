using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{


    public sealed class CameraController: IExecute
    {

        private Transform _player;
        private Transform _mainCamera;
        public Vector3 _offset;


        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }


        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;
        }
    }

}
