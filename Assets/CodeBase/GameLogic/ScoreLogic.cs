using Assets.CodeBase.GameField.FieldCleaner;
using System;
using UnityEngine;

namespace Assets.CodeBase.GameLogic
{
    public class ScoreLogic
    {
        private const int ScoreForOneLine = 100;
        private const int ScoreForTwoLine = 300;
        private const int ScoreForThreeLine = 700;
        private const int ScoreForFourLine = 1500;

        private CleanerHolder _cleanerHolder;
        private ScoreText _scoreText;

        private int _lines;
        private int _linesBefore;

        private int _count;

        public void Construct(CleanerHolder cleanerHolder, ScoreText scoreText)
        {
            _cleanerHolder = cleanerHolder;
            _scoreText = scoreText;
        }

        public int Count => _count;

        public void Update()
        {
            _lines = _cleanerHolder.Lines;

            if (_lines != _linesBefore)
            {
                Scoring();

                _linesBefore = _lines;
                _scoreText.UpdateScore(_count);
            }
        }

        private void Scoring()
        {
            int difference = _lines - _linesBefore;

            _count += difference switch
            {
                1 => ScoreForOneLine,
                2 => ScoreForTwoLine,
                3 => ScoreForThreeLine,
                4 => ScoreForFourLine,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
