using System;
using System.Collections;
using System.Collections.Generic;
using Achievement;
using Achievement.Processor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.GUI
{
    public class AchievementsGUI : MonoBehaviour
    {
        [SerializeField] private List<Text> gui = new List<Text>();
        
        private void Start()
        {
            IAchievementsProcessor processor = FindObjectOfType<AchievementsProcessorImpl>();
            DrawGUI(processor.GetCurrentAchievements());
            processor.RegisterUpdateCurrentAchievementsListener(DrawGUI);
        }

        private void DrawGUI(List<AchievementInfo> achievementInfos)
        {
            for (var i = 0; i < gui.Count; i++)
            {
                var item = achievementInfos[i];
                gui[i].text = $"{item.Title}  -  {item.Progress.Current}/{item.Progress.Target}";
            }
        }
    }
}