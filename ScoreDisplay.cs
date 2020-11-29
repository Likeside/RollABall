using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{

    public sealed class ScoreDisplay
    {
        private Text _bonusScoreLabel;
        
        public ScoreDisplay(GameObject bonusScoreObj)
        {
            //Заменить на загрузку из кода
            //_text = Object.FindObjectOfType<Text>();
            _bonusScoreLabel = bonusScoreObj.GetComponentInChildren<Text>();
            _bonusScoreLabel.text = String.Empty;
        }
        
        public void Display(int score)
        {
            _bonusScoreLabel.text = $"Вы набрали {score}" +" очков.";
        }

    }

}
