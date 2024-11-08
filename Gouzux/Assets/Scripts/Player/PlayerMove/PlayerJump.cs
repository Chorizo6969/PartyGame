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
    private float _distance;

    public bool IsGrounded;
    public static PlayerJump Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            DetectHit(transform.localPosition, _distance, new Vector3(0, -1, 0));
            if (IsGrounded == true)
            {
                _rb.AddForce(new Vector2(0, _jumpForce * 10));
                StartCoroutine(Delay());
            }
        }
        Debug.Log("AH");
    }

    /// <summary>
    /// Fonction qui trace un raycast pour savoir si le joueur peut sauter ou non
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="distance"></param>
    /// <param name="direction"></param>
    void DetectHit(Vector3 startPos, float distance, Vector3 direction)
    {
        RaycastHit2D hit;
        Vector3 endPos = startPos + (distance * direction);
        int layerMask = 1 << 6;
        hit = Physics2D.BoxCast(startPos, new Vector2 (1 ,0.8f), 90, direction, distance, layerMask);
        if (hit.collider == null) //Vérification que l'on touche bien un collider (sinon null ref)
        {
            Debug.Log("Attention vous ne touchez rien");
            return;
        }
        if (hit.collider.gameObject.layer == 6)
        {
            IsGrounded = true;
            endPos = hit.point;
        }
        Debug.DrawLine(startPos, endPos, Color.red);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.05f);
        IsGrounded = false;
    }
}
