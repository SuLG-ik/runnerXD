using System.Collections.Generic;
using UnityEngine;

namespace World.Map
{
    public class MapsCollection : MonoBehaviour, IMapsCollection

    {
        [SerializeField] public List<MapPart> scenes;

        public List<MapPart> GetScenes()
        {
            return scenes;
        }
    }
}