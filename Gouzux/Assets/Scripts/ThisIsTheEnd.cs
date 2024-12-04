using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsTheEnd : MonoBehaviour
{
    [SerializeField] GameObject _THEEND;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _THEEND.SetActive(true);
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }
}
