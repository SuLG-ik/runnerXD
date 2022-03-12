using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace MainMenu
{
    public class MainMenuButtons : MonoBehaviour
    {
        [Inject] private INavigator _navigator;
        public void OnPlay()
        {
            _navigator.NavigateToGame();
        }


        public void OnTasks()
        {
            
        }

        public void OnReset()
        {
            
        }
    }
}