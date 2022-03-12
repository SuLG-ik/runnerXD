using UnityEngine;

namespace World.Map
{
    public interface IMapCreator 
    {
        public void DestroyAndSpawnMap(Map map);
    }
}