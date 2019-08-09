using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObj = other.gameObject;
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
