using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField] public bool _isOnCrate;

    public Rigidbody2D boxRigidbody;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isOnCrate && boxRigidbody.transform.position.y < transform.position.y)
        {
            //Vector2 boxVelocity = boxRigidbody.velocity;
            _rb.velocity += new Vector2(boxRigidbody.velocity.x, boxRigidbody.velocity.y);
            Debug.Log("AAAAAAAAAAAAAH");
        }

        //Debug.Log("Velocity " + gameObject.name + " : " + _rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) // Sol
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        if ((collision.gameObject.layer == 7 || collision.gameObject.layer == 9)) // Caisses ou player
        {
            //Debug.Log("truc sur ma tete");
            if (collision.transform.position.y < transform.position.y)
            {
                _isOnCrate = true;
            }
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
