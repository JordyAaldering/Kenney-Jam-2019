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
        Destroy(gameObject, _lifetime);
    }

    public void Shoot(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * _speed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObj = other.gameObject;
        
        if (otherObj == Parent)
            return;
        
        if (otherObj.CompareTag("Player"))
        {
            otherObj.GetComponent<PlayerController>().Health -= _damage;
        }
        else if (otherObj.CompareTag("Enemy"))
        {
            
        }
        
        Destroy(gameObject);
    }
}
