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

        public GameOverDisplay(Text gameOverLabel)
        {
            _gameOverLabel = gameOverLabel;
            _gameOverLabel.text = String.Empty;
        }

        public void GameOver(object catchingplayer, CaughtPlayerEventArgs args)
        {
            _gameOverLabel.text = $"Вы проиграли, Вас убил куб с цветом: {args.Color}";
        }
    }

}
