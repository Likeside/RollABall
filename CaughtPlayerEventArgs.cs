using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CaughtPlayerEventArgs : EventArgs
{
    public Color Color { get; }

    public CaughtPlayerEventArgs(Color color)
    {
        this.Color = color;
    }
}
