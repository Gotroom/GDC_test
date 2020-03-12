using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


namespace GDCTest
{
    public class SceneController : MonoBehaviour
    {
        public void Awake()
        {
            UIMenu.ExitPressed = OnExit;
            UIMenu.NewGamePressed = OnNewGame;
        }

        private void OnExit()
        {
            Application.Quit();
        }

        private void OnNewGame()
        {
            StartCoroutine(LoadSceneAsync());
        }

        IEnumerator LoadSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync(Constants.DEFAULT_SCENE, LoadSceneMode.Single);
        }
    }
}

