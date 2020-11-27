using System;
using System.Collections;
using System.Collections.Generic;
using RollABall;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollABall
{
    
    public sealed class BadBonus : InteractiveObject, IFlying, IRotating
    {
        [SerializeField] private float _minFlightDistance = 1.0f;
        [SerializeField] private float _maxFlightDistance = 5.0f;
        [SerializeField] private float _minRotationSpeed = 10f;
        [SerializeField] private float _maxRotationSpeed = 50f;
        private float _flightDistance;
        private float _rotationSpeed;
        
       // public delegate void CatchPlayer(object catchingobject);
       // public event CatchPlayer CaughtPlayer;

        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer; 
        
        private void Awake()
        {
            _flightDistance = Random.Range(_minFlightDistance, _maxFlightDistance);
            _rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        }

        protected override void Interaction()
        {
            CaughtPlayer?.Invoke(this, new CaughtPlayerEventArgs(_color));
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time,_flightDistance), transform.localPosition.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.Self);

        }
    }

}
