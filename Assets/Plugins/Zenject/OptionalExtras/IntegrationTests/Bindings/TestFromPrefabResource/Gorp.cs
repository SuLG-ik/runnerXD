﻿#region

using ModestTree;
using UnityEngine;

#endregion

#pragma warning disable 649

namespace Zenject.Tests.Bindings.FromPrefabResource
{
    public class Gorp : MonoBehaviour
    {
        [Inject] private string _arg;

        [Inject]
        public void Initialize()
        {
            Log.Trace("Received arg '{0}' in Gorp", _arg);
        }
    }
}