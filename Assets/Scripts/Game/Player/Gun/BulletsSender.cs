using System;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(IPlayer))]
    public class BulletsSender : SuspendableMonoBehaviour, ISuspendable
    {
        [SerializeField] private GameObject bullet;

        private IState _state = new Continued();

        protected override void Start()
        {
            base.Start();
            var player = GetComponent<IPlayer>();
            player.GetGun().RegisterShootListener(() => { _state.Update(this); });
        }


        public override void Continue()
        {
            _state = new Continued();
        }

        public override void Suspend()
        {
            _state = new Suspended();
        }

        private interface IState
        {
            public void Update(BulletsSender sender);
        }

        private sealed class Suspended : IState
        {
            public void Update(BulletsSender sender)
            {
                throw new NotImplementedException();
            }
        }

        private sealed class Continued : IState
        {
            public void Update(BulletsSender sender)
            {
                Instantiate(sender.bullet, sender.transform.position + new Vector3(2, 0), Quaternion.identity);
            }
        }
    }
}