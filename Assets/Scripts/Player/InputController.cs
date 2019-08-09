using UnityEngine;

namespace Player
{
    public class InputController : MonoBehaviour
    {
        private PlayerController _player;
        private Rotator _rotator;
        private Camera _cam;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _rotator = FindObjectOfType<Rotator>();
            _cam = Camera.main;
        }

        private void Update()
        {
            UpdateRotate();
            UpdateJump();
            UpdateShoot();
        }

        private void UpdateRotate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (Mathf.Abs(horizontal) > 0f)
            {
                _rotator.Rotate(horizontal);
            }
        }

        private void UpdateJump()
        {
            if (Input.GetAxisRaw("Jump") > 0f)
            {
                _player.Jump();
            }
        }

        private void UpdateShoot()
        {
            Vector2 pos = transform.position;
            Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - pos).normalized;

            if (Input.GetAxisRaw("Fire1") > 0f)
            {
                _player.Shoot(direction);
            }
        }
    }
}
