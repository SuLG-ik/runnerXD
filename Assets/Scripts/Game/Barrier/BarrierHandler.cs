using UnityEngine;
using World.Barriers;

namespace Game.Barrier
{
    public class BarrierHandler : SuspendableMonoBehaviour
    {
        private IState _state = new Continued();

        private void OnTriggerEnter2D(Collider2D col)
        {
            _state.Update(col);
        }

        public override void Suspend()
        {
            _state = new Suspended();
        }

        public override void Continue()
        {
            _state = new Continued();
        }


        private interface IState
        {
            public void Update(Collider2D collider);
        }

        private sealed class Suspended : IState
        {
            public void Update(Collider2D collider)
            {
            }
        }

        private sealed class Continued : IState
        {
            public void Update(Collider2D collider)
            {
                if (!collider.CompareTag("barrier")) return;
                var barrier = collider.GetComponent<IBarrier>();
                barrier.OnCollision();
            }
        }
    }
}