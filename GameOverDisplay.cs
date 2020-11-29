using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{

    public sealed class GameOverDisplay
    {
        private Text _gameOverLabel;

        public GameOverDisplay(GameObject gameOverObj)
        {
            //Заменить на загрузку из кода
           // _gameOverLabel = gameOverLabel;
            //_gameOverLabel.text = String.Empty;
            _gameOverLabel = gameOverObj.GetComponentInChildren<Text>();
            _gameOverLabel.text = String.Empty;

        }

        public void GameOver(object catchingplayer, CaughtPlayerEventArgs args)
        {
            _gameOverLabel.text = $"Вы проиграли, Вас убил куб с цветом: {args.Color}";
        }
    }

}
