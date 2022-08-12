using UnityEngine;
using UnityEngine.UI;
using Asteroids.Interpreter;
using System;

namespace Asteroids.CommandUI
{
    internal sealed class ScorePanel : MainUI
    {
        [SerializeField] private Text _score;

        public override void ShowPanel()
        {
            _score.text = typeof(ScorePanel).ToString();
            gameObject.SetActive(true);

            InterpretScore(_score.text);
        }

        public override void HidePanel()
        {
            gameObject.SetActive(false);
        }

        private void InterpretScore(string score)
        {
            if (Int64.TryParse(score, out var number))
            {
                _score.text = number.ToAbbreviatedString();
            }
        }
    }
}
