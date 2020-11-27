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
            //Заменить на загрузку из кода
            //_text = Object.FindObjectOfType<Text>();
        }
        
        public void Display(int score)
        {
            _text.text = $"Вы набрали {score}" +" очков.";
        }

    }

}
