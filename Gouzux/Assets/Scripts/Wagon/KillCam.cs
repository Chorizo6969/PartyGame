using Cinemachine;
using UnityEngine;

public class KillCam : MonoBehaviour
{
    [SerializeField]
    private CinemachineImpulseSource _impulseSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            PlayerDeath.Instance.StartDeath(_impulseSource, collision.gameObject);
        }
    }
}
