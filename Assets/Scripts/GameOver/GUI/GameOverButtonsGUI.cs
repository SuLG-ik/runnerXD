using System;
using UnityEngine;
using Utils;
using Zenject;

namespace GameOver.GUI
{
    public class GameOverButtonsGUI : MonoBehaviour
    {
        [Inject]
        private INavigator _navigator;

        public void OnPlayAgain()
        {
            _navigator.NavigateToGame();
        }

        public void OnGoMainMenu()
        {
            _navigator.NavigateToMainMenu();
        }
    }
}