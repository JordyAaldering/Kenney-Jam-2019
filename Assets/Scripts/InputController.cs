using UnityEngine;

public class InputController : MonoBehaviour
{
    private Rotator _rotator;

    private void Awake()
    {
        _rotator = FindObjectOfType<Rotator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontal) > 0f)
        {
            _rotator.Rotate(horizontal);
        }
    }
}
