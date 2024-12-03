using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    private bool _canMove = true;
    [SerializeField] public bool _isOnCrate;

    [SerializeField] private Rigidbody2D boxRigidbody;


    private void FixedUpdate()
    {
        if (_isOnCrate && boxRigidbody.transform.position.y > transform.position.y)
        {
            //Vector2 boxVelocity = boxRigidbody.velocity;
            boxRigidbody.velocity += new Vector2(_rb.velocity.x, boxRigidbody.velocity.y);
            Debug.Log("AAAAAAAAAAAAAH");
        }

        Debug.Log("Velocity " + gameObject.name + " : " + _rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) // Sol
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        if ((collision.gameObject.layer == 7 || collision.gameObject.layer == 9) && collision.transform.position.y > transform.position.y) // Caisses ou player
        {
            Debug.Log("truc sur ma tete");
            _isOnCrate = true;
            boxRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            _rb.velocity = new Vector2(boxRigidbody.velocity.x, _rb.velocity.y);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9)
        {
            _isOnCrate = false;
            boxRigidbody = null;
        }
    }
}
