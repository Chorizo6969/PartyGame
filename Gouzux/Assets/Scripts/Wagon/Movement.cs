using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private float _speed = 2;

    private void FixedUpdate()
    {
        // Déplace le wagon horizontalement
        _rb.velocity = new Vector2(_speed, _rb.velocity.y);
    }
}
