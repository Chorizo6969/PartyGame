using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script sur le joueur lui permettant de sauter si il touche le sol
/// </summary>
public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private Transform _groundCheck;

    public static PlayerJump Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
        if (callbackContext.canceled && _rb.velocity.y > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
}
