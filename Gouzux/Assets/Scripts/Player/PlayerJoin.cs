using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager _playerInputManager;

    public async void OnJoin()
    {
        if (_playerInputManager.playerCount == 1)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
            await Task.Delay(1000);
        }
        else if(_playerInputManager.playerCount == 2)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            await Task.Delay(1000);
        }
        else if (_playerInputManager.playerCount == 3)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.green;
            await Task.Delay(1000);
        }
        else if (_playerInputManager.playerCount == 4)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
            await Task.Delay(1000);
        }
    }
    private void Update()
    {
        Debug.Log(_playerInputManager.playerCount);
    }
}
