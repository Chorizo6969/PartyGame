using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    private AnimationClip _clip;

    [SerializeField]
    private CinemachineImpulseSource impulseSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.SetActive(false);
            StartCoroutine(DelayBeforeReset());
        }
    }

    IEnumerator DelayBeforeReset()
    {
        //VFX Mort
        CameraShakeManager.Instance.CameraShake(impulseSource);
        AnimationStart.Instance.MakeAnimation(_clip);
        yield return new WaitForSeconds(1f);
        ChangeScene.Instance.ChargeScene();
    }
}
