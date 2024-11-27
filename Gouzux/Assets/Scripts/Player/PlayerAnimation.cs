using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody2D _rb; //Le rigidbody est utilisé pour voir la vélocité du joueur et agir en conséquence

    public static PlayerAnimation Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (_rb.velocity.x <= 0 && _rb.velocity.x > -1)
        {
            _animator.SetFloat("XVelocity", 0);
        }
        else
        {
            _animator.SetFloat("XVelocity", 1);
        }
    }

    /// <summary>
    /// Lance l'animation de saut du joueur
    /// </summary>
    public void SetJump()
    {
        _animator.SetBool("IsJump", true);
        string name = "IsJump";
        StartCoroutine(DesactiveAnystate(name));
    }

    IEnumerator DesactiveAnystate(string BoolName)
    {
        yield return new WaitForSeconds(0.3f);
        _animator.SetBool(BoolName, false);
    }
}
