using Cinemachine;
using UnityEngine;

/// <summary>
/// Script qui gère le comportement d'une deathzone
/// </summary>
public class DeathZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _parent;
    [SerializeField]
    private CinemachineImpulseSource _impulseSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
        {
            PlayerDeath.Instance.StartDeath(_impulseSource, collision.gameObject);
        }
        if(collision.gameObject.layer == 9)
        {
            Destroy(_parent);
        }
    }
}
