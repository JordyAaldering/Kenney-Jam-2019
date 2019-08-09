#pragma warning disable 0649
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _health = 10f;
    public float Health
    {
        get => _health;
        set
        {
            _health = value;
            CheckDeath();
        }
    }
    
    [SerializeField] private float _cooldown = 5f;
    [SerializeField] private float _viewDistance = 5f;
    
    [SerializeField] private LayerMask _mask = ~(1 << 9);
    [SerializeField] private GameObject _bulletPrefab;

    private Transform _player;
    private bool _canShoot;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
        Invoke(nameof(EnableShoot), _cooldown);
    }
    
    private void CheckDeath()
    {
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        if (!_canShoot)
            return;
        
        Vector3 pos = transform.position;
        Vector3 direction = (_player.position - pos).normalized;
        RaycastHit2D hit = Physics2D.Raycast(pos, direction, _viewDistance, _mask);

        if (hit && hit.collider.CompareTag("Player"))
        {
            Shoot(direction);
        }
    }

    private void Shoot(Vector3 direction)
    {
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
}
