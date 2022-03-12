using System;
using Achievement;
using Achievement.Events;
using UnityEngine;
using Zenject;

namespace World.Barriers
{
    public abstract class MovableBarrier : SuspendableMonoBehaviour, IBarrier
    {
        private IBarrierCreator _barrierGenerator;

        private IBarrierCreator GetBarrierCreator()
        {
            return _barrierGenerator ??= FindObjectOfType<BarrierCreator>();
        }


        private IState _state = new Continued();

        private void Update()
        {
            _state.Update(this);
        }

        public abstract void OnCollision();

        public abstract GameObject GetGameObject();

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
            public void Update(MovableBarrier barrier);
        }

        private sealed class Suspended : IState
        {
            public void Update(MovableBarrier barrier)
            {
                
            }
        }

        private sealed class Continued : IState
        {
            public void Update(MovableBarrier barrier)
            {
                var position = barrier.gameObject.transform.position;
                var newPosition = new Vector2(
                    position.x + barrier.GetBarrierCreator().GetBarrierMovement() * Time.deltaTime,
                    position.y);
                barrier.gameObject.transform.position = newPosition;
                if (barrier.transform.position.x <= -25)
                {
                    barrier.GetBarrierCreator().DestroyBarrier(barrier);
                }
            }
        }
    }
}