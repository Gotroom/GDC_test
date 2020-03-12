using UnityEngine;


namespace GDCTest
{
    public class MenuController : BaseController, IInitializable
    {
        public void Initialize()
        {
            Time.timeScale = 1.0f;
            InputController.CancelPressed = OnShowMenu;
            TimeController.TimerExpired = OnTimerExpired;
        }

        private void OnShowMenu()
        {
            bool isActive = UiInterface.EndGameMenu.IsActive;
            Time.timeScale = !isActive ? 0.0f : 1.0f;
            UiInterface.EndGameMenu.SetActive(!isActive);
        }

        private void OnTimerExpired()
        {
            InputController.CancelPressed -= OnShowMenu;
            TimeController.TimerExpired -= OnTimerExpired;
            OnShowMenu();
            UiInterface.EndGameMenu.ScoreText = UiInterface.ScoreText.Score;
        }
    }
}