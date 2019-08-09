using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    public float Health
    {
        get => _health;
        set
        {
            _health -= value;
            CheckDeath();
        }
    }
    
    [SerializeField] private float _cooldown = 5f;
    [SerializeField] private GameObject _bulletPrefab;

    private bool _canShoot = true;
    
    private void CheckDeath()
    {
        if (_health <= 0f)
        {
            FindObjectOfType<GameController>().GameOver();
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
            FindObjectOfType<GameController>().LevelComplete();
        }
    }
}
