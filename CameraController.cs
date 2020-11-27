using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{


    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        public Vector3 _offset;

        // Start is called before the first frame update
        void Start()
        {
            _offset = transform.position - _player.transform.position;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }
    }

}
