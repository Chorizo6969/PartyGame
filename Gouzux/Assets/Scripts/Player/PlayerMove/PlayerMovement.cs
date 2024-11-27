using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script qui gère les mouvements du joueur
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    private Vector2 _inputMovement;

    [SerializeField]
    private float _speed;

    private bool _canMove = true;

    public static PlayerMovement Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        _inputMovement = callbackContext.ReadValue<Vector2>();
        if (callbackContext.canceled)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }

    private void Update()
    {
        if (_inputMovement.x != 0 && _canMove)
        {
            if (_inputMovement.x > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
                _rb.velocity = new Vector2(_inputMovement.x * _speed, _rb.velocity.y);
            }
            else if (_inputMovement.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                _rb.velocity = new Vector2(_inputMovement.x * _speed, _rb.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }
    }
}