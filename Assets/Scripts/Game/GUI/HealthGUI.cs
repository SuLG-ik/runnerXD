using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.GUI
{
    public class HealthGUI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> gui = new List<GameObject>();

        private void Start()
        {
            var health = FindObjectOfType<PlayerHealth>();
            health.RegisterUpdateHeathListener((newHealth, damage) => { UpdateHealth(newHealth); });
        }

        private void UpdateHealth(int health)
        {
            DrawGUI(health);
        }

        private void DrawGUI(int health)
        {
            for (var i = 0; i < gui.Count; i++)
            {
                var item = gui[i];
                item.SetActive(i <= health - 1);
            }
        }
    }
}