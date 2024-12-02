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

    public static PlayerMovement Instance;
    private Rigidbody2D boxRigidbody;

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

    private void FixedUpdate()
    {
        if (_inputMovement.x != 0 && _canMove)
        {
            _rb.velocity = new Vector2(_inputMovement.x * _speed, _rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, _inputMovement.x > 0 ? 0 : 180, transform.rotation.z));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) // Sol
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9) // Caisses
        {
            boxRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            _rb.velocity = new Vector2(boxRigidbody.velocity.x, _rb.velocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.layer == 7 || collision.gameObject.layer == 9) && boxRigidbody != null)
        {
            print("f");
            // Synchroniser le mouvement horizontal du joueur avec celui de la caisse
            Vector2 boxVelocity = boxRigidbody.velocity;
            _rb.velocity = new Vector2(boxVelocity.x, _rb.velocity.y);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9)
        {
            boxRigidbody = null;
        }
    }
}
