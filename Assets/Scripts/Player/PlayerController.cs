#pragma warning disable 0649
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _health = 100f;

        public float Health
        {
            get => _health;
            set
            {
                _health = value;
                CheckDeath();
            }
        }

        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _jumpOffset = 0.5f;
        [SerializeField] private LayerMask _jumpMask = ~(1 << 8);

        [SerializeField] private float _cooldown = 5f;
        [SerializeField] private GameObject _bulletPrefab;

        private bool _canShoot = true;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void CheckDeath()
        {
            if (_health <= 0f)
            {
                GameController.GameOver();
            }
        }

        public void Jump()
        {
            Vector2 pos = transform.position;
            Vector2 direction = Vector2.down;
            RaycastHit2D hit = Physics2D.Raycast(pos, direction, _jumpOffset, _jumpMask);

            if (hit)
            {
                _rb.AddForce(new Vector2(0f, _jumpForce));
            }
        }

        public void Shoot(Vector2 direction)
        {
            if (!_canShoot)
                return;

            _canShoot = false;
            Invoke(nameof(EnableShoot), _cooldown);

            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            Projectile projectile = bullet.GetComponent<Projectile>();
            projectile.Parent = gameObject;
            projectile.Shoot(direction);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.Rotate(0f, 0f, angle);
        }

        private void EnableShoot()
        {
            _canShoot = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Exit"))
            {
                GameController.LevelComplete();
            }
        }
    }
}
