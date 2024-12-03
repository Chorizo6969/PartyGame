using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChange : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonStart;

    [SerializeField]
    private GameObject _buttonPause;

    [SerializeField]
    private EventSystem _eventSystem;


    public void EventSystemChangeStart()
    {
        _eventSystem.SetSelectedGameObject(_buttonStart);
    }
}
