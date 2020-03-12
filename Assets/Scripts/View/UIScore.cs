using UnityEngine;
using UnityEngine.UI;

namespace GDCTest
{
    public class UIScore : MonoBehaviour
    {
        public int Score
        {
            get => _currentScore;
        }

        private int _currentScore = 0;
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _text.text = $"Score: {_currentScore}";
        }

        private void OnEnable()
        {
            CirclesController.IncreaseScore += OnIncreaseScore;
        }

        private void OnDisable()
        {
            CirclesController.IncreaseScore -= OnIncreaseScore;
        }

        private void OnIncreaseScore(int points)
        {
            _currentScore += points;
            _text.text = $"Score: {_currentScore}";
        }
    }
}