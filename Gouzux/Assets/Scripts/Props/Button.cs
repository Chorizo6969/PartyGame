using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _spikeList = new();

    public void SpikeOff()
    {
        foreach (GameObject obj in _spikeList)
        {
            //Changer le sprite du pique ou anim
            obj.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9)
        {
            //Changer le sprite du bouton ou anim
            SpikeOff();
            Destroy(gameObject);
        }
    }
}
