using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;

    public void Rotate(float direction)
    {
        transform.Rotate(0f, 0f, -direction * _rotateSpeed * Time.deltaTime);
    }
}
