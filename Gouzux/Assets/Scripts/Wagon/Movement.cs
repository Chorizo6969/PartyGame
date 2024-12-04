using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 2;

    public bool _canMove = false;

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.R))
        {
            ChangeScene.Instance.ChargeScene();
        }

    }
}
