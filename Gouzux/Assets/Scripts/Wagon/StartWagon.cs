using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWagon : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DelayBeforePlay());
    }

    IEnumerator DelayBeforePlay()
    {
        yield return new WaitForSeconds(2.5f);
        this.GetComponent<Movement>()._canMove = true;
    }
}
