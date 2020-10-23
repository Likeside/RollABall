using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    
    public class PlayerBall : Player
    {
        public PlayerBall(float speed) : base(speed)
        {

        }

        private void FixedUpdate()
        {
            Move();
        }
    }
}
