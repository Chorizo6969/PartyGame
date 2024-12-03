using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    private Vector2 _inputMovement;

    [SerializeField]
    private float _speed;

    private bool _canMove = true;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        _inputMovement = callbackContext.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rb.velocity = new Vector2(_inputMovement.x * _speed, _rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, _inputMovement.x > 0 ? 0 : 180, transform.rotation.z));
        }
    }
}
