using System.Collections;
using System.Collections.Generic;
using RollABall;
using UnityEngine;

namespace RollABall
{

    public interface IInteractable : IAction
    {
        bool IsInteractable { get; }
    }

}
