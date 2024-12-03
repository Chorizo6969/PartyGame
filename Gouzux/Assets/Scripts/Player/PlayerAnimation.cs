using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb; //Le rigidbody est utilisé pour voir la vélocité du joueur et agir en conséquence

    void Update()
    {
        if (_rb.velocity.x <= 0 && _rb.velocity.x > -1)
        {
            GetComponent<Animator>().SetFloat("XVelocity", 0);
        }
        else
        {
            GetComponent<Animator>().SetFloat("XVelocity", 1);
        }
    }

    /// <summary>
    /// Lance l'animation de saut du joueur
    /// </summary>
    public void SetJump()
    {
        GetComponent<Animator>().SetBool("IsJump", true);
    }
}
