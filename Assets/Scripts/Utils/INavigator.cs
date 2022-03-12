using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public interface INavigator
    {

        public void NavigateToGame();

        public void NavigateToMainMenu();

        public void NavigateToGameOver();

    }
}