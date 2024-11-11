using Cinemachine;
using System.Collections;
using UnityEngine;

/// <summary>
/// Script qui gère la mort d'un des joueurs
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private AnimationClip _clip;

    public static PlayerDeath Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void StartDeath(CinemachineImpulseSource _impulseSource, GameObject Player)
    {
        StartCoroutine(DelayBeforeReset(_impulseSource, Player));
    }

    IEnumerator DelayBeforeReset(CinemachineImpulseSource _impulseSource, GameObject Player)
    {
        //VFX Mort
        Player.SetActive(false); //A l'avenir il faudra que ça tue le joueur mort
        CameraShakeManager.Instance.CameraShake(_impulseSource);
        AnimationFonduManager.Instance.MakeAnimation(_clip);
        yield return new WaitForSeconds(1f);
        ChangeScene.Instance.ChargeScene();
    }
}
