using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{

    public sealed class DataSaver<T> where T: struct
    {
        public int score;
        public T PlayerID = default;
    }

}
