using DefaultNamespace;

public class Box : Hittable
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
