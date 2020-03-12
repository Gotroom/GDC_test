using UnityEngine;

namespace GDCTest
{
    public sealed class UIInterface
    {
        private UIScore _score;

        public UIScore ScoreText
        {
            get
            {
                if (!_score)
                    _score = Object.FindObjectOfType<UIScore>();
                return _score;
            }
        }

        private UITimer _timer;

        public UITimer TimerText
        {
            get
            {
                if (!_timer)
                    _timer = Object.FindObjectOfType<UITimer>();
                return _timer;
            }
        }

        private UIMenu _menu;

        public UIMenu EndGameMenu
        {
            get
            {
                if (!_menu)
                    _menu = Object.FindObjectOfType<UIMenu>();
                return _menu;
            }
        }
    }
}