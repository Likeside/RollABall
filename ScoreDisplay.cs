using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{

    public sealed class ScoreDisplay
    {
        private Text _text;
        public ScoreDisplay()
        {
            _text = Object.FindObjectOfType<Text>();
        }
        
        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}" +" очков.";
        }

    }

}
