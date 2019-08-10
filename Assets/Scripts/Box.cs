using DefaultNamespace;

public class Box : Hittable
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
