using System;
using System.Collections.Generic;
using Game.Player;
using UnityEngine;
using World.Barriers;
using World.Map;

namespace Game
{
    public class GameProcessor : MonoBehaviour, ISuspendable
    {
        private readonly List<ISuspendable> _suspendables = new List<ISuspendable>();

        public void RegisterSuspendable(ISuspendable suspendable)
        {
            _suspendables.Add(suspendable);
        }

        public void UnregisterSuspendable(ISuspendable suspendable)
        {
            _suspendables.Add(suspendable);
        }

        public void Suspend()
        {
            foreach (var suspendable in _suspendables)
            {
                suspendable.Suspend();
            }
        }

        public void Continue()
        {
            foreach (var suspendable in _suspendables)
            {
                suspendable.Continue();
            }
        }

        private void OnDestroy()
        {
            _suspendables.Clear();
        }
    }
}