using UnityEngine;

namespace Game.Player.Gun
{
    public class Bullet : SuspendableMonoBehaviour
    {
        [SerializeField] private Vector2 speed;

        private IState _state = new Continued();

        private void Update()
        {
            _state.Update(this);
        }

        private void Move()
        {
            transform.position = new Vector2(transform.position.x + speed.x * Time.deltaTime,
                transform.position.y + speed.y * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("barrier")) return;
            Destroy(col.gameObject);
            Destroy(gameObject);
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
            public void Update(Bullet bullet);
        }

        private sealed class Suspended : IState
        {
            public void Update(Bullet bullet)
            {
            }
        }

        private sealed class Continued : IState
        {
            public void Update(Bullet bullet)
            {
                bullet.Move();
            }
        }
    }
}