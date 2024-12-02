using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager _playerInputManager;

    public void OnJoin()
    {
        if (_playerInputManager.playerCount == 2)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        }
        else if(_playerInputManager.playerCount == 1)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else if (_playerInputManager.playerCount == 3)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
        else if (_playerInputManager.playerCount == 4)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
    }
}
