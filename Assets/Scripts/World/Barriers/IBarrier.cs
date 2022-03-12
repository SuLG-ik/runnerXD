using UnityEngine;

namespace World.Barriers
{
    public interface IBarrier
    {       

        void OnCollision();

        GameObject GetGameObject();

    }
}