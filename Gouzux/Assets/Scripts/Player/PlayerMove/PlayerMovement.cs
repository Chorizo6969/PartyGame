using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
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

    private CharacterController _controller;

    public static PlayerMovement Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _controller = gameObject.AddComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("as");
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
}