using UnityEngine;
using World.Barriers;

namespace Game.Player.Gun
{
    public class BulletBarrier : MovableBarrier
    {
        public override void OnCollision()
        {
            FindObjectOfType<PlayerCore>().GetGun().UpdateBulletsAmount(1);
            Destroy(gameObject);
        }

        public override GameObject GetGameObject()
        {
            return gameObject;
        }
    }
}