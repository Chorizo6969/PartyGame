using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _sprite = new List<GameObject>();

    private int _count = 0; 

    public void OnJoin()
    {
        _sprite[_count].SetActive(true);
        _count++;
    }
}
