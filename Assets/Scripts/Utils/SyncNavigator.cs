using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SyncNavigator: INavigator
    {

        public void NavigateToGame()
        {
            SceneManager.LoadScene("Scenes/Game");
        }

        public void NavigateToMainMenu()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        public void NavigateToGameOver()
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }

    }
}