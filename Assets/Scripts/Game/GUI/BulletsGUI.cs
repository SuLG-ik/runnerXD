using System;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.GUI
{
    public class BulletsGUI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> gui = new List<GameObject>();

        private void Start()
        {
            IPlayer player = FindObjectOfType<PlayerCore>();
            UpdateBullets(player.GetGun().GetBulletsAmount());
            player.GetGun().RegisterUpdateBulletsAmountListener((newHealth, damage) => { UpdateBullets(newHealth); });
        }

        private void UpdateBullets(int health)
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