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

    private void CheckDeath()
    {
        if (_health <= 0f)
        {
            FindObjectOfType<GameController>().GameOver();
        }
    }
    
    public void Aim(Vector2 direction)
    {
        
    }

    public void Shoot(Vector2 direction)
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            FindObjectOfType<GameController>().LevelComplete();
        }
    }
}
