using UnityEngine;
using Cinemachine;

/// <summary>
/// Script qui g�re la mani�re du screen shake
/// </summary>
public class CameraShakeManager : MonoBehaviour
{
    [SerializeField]
    private float globalShakeForce = 1f;

    public static CameraShakeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }
}
