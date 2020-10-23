using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.IO;
using  UnityEngine.Animations;

namespace RollABall
{

    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;

        public Player(float speed)
        {
            _speed = speed;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * _speed);
        }
    }
}