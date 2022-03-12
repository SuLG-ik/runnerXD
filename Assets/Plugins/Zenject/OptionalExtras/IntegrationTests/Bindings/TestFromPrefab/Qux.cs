﻿#region

using ModestTree;
using UnityEngine;

#endregion

#pragma warning disable 649

namespace Zenject.Tests.Bindings.FromPrefab
{
    public class Qux : MonoBehaviour
    {
        [Inject] private int _arg;

        [Inject]
        public void Initialize()
        {
            Log.Trace("Received arg '{0}' in Qux", _arg);
        }
    }
}