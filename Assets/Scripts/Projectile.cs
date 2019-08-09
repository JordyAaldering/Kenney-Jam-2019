#pragma warning disable 0649
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _lifetime = 5f;
    
    private GameObject _parent;
    public GameObject Parent
    {
        private get => _parent;
        set
        {
            Debug.Assert(!_parent, "A parent has already been set.");
            _parent = value;
        }
    }

    private void Awake()
    {
        transform.parent = FindObjectOfType<Rotator>().transform;
        
        Destroy(gameObject, _lifetime);
    }

    public void Shoot(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * _speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Parent)
            return;
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Health -= _damage;
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Health -= _damage;
        }
        
        Destroy(gameObject);
    }
}
