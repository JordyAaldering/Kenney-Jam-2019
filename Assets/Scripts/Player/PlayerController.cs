#pragma warning disable 0649
using System.Collections;
using UI;
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

        [SerializeField] private int _ammo;
        private int Ammo
        {
            get => _ammo;
            set
            {
                _ammo = value;
                _ammoPanel.SetAmmo(_ammo);
            }
        }
        
        private bool _canShoot = true;
        private Rigidbody2D _rb;
        private AmmoPanel _ammoPanel;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _ammoPanel = FindObjectOfType<AmmoPanel>();
            
            _ammoPanel.SetAmmo(_ammo);
            _ammoPanel.SetCooldown(1f);
        }

        private void CheckDeath()
        {
            if (_health <= 0f)
            {
                FindObjectOfType<GameController>().GameOver();
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
            if (!_canShoot || _ammo < 1)
                return;

            _canShoot = false;
            Ammo--;
            StartCoroutine(EnableShoot());

            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            Projectile projectile = bullet.GetComponent<Projectile>();
            projectile.Parent = gameObject;
            projectile.Shoot(direction);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.Rotate(0f, 0f, angle);
        }

        private IEnumerator EnableShoot()
        {
            float currentCooldown = _cooldown;

            while (currentCooldown > 0f)
            {
                currentCooldown -= Time.deltaTime;
                _ammoPanel.SetCooldown((_cooldown - currentCooldown) / _cooldown);
                
                yield return null;
            }
            
            _canShoot = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Exit"))
            {
                FindObjectOfType<GameController>().LevelComplete();
            }
        }
    }
}
