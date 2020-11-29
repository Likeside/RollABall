using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.IO;
using  UnityEngine.Animations;

namespace RollABall
{

    public abstract class PlayerBase : MonoBehaviour
    {
        [SerializeField] public float Speed = 3f;
        public abstract void Move(float x, float y, float z);
    }

}