using UnityEngine;
using UnityEngine.UI;
using System;

namespace GDCTest
{
    public class UIMenu : MonoBehaviour
    {
        public static Action ExitPressed;
        public static Action NewGamePressed;

        public bool IsActive
        {
            get => _menuObject.activeSelf;
        }

        [SerializeField] private GameObject _menuObject;

        [SerializeField] private Text _text;

        public int ScoreText
        {
            set
            {
                _text.text = $"Final score: {value}";
            }
        }

        public void OnNewGamePressed()
        {
            NewGamePressed?.Invoke();
        }

        public void OnExitPressed()
        {
            ExitPressed?.Invoke();
        }

        public void SetActive(bool value)
        {
            _menuObject.SetActive(value);
        }
    }
}
