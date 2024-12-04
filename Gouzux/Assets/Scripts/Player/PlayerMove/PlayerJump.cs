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

    [SerializeField] private LayerMask _groundLayer1;

    [SerializeField] private LayerMask _groundLayer3;

    [SerializeField] private LayerMask _groundLayer4;

    [SerializeField]
    private Transform _groundCheck;
    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && IsGrounded() && (GetComponent<Crate>()._isOnCrate == (GetComponent<Crate>().boxRigidbody != null)))
        {
            GetComponent<PlayerAnimation>().SetJump();
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
        if (callbackContext.canceled && _rb.velocity.y > 0 && !GetComponent<Crate>()._isOnCrate)
        {
            GetComponent<PlayerAnimation>().SetJump();
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer1) || Physics2D.OverlapCircle(_groundCheck.position, 0.2f ,_groundLayer4) || Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer3);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "solide" || collision.gameObject.layer == 7)
        {
            GetComponent<Animator>().SetBool("IsJump", false);
        }
    }
}
