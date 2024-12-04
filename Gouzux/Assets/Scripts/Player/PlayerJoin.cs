using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager _playerInputManager;

    public int jetesauvelavie = 0;
    private void Awake()
    {
        _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
    }
    public async void OnJoin()
    {
        if (jetesauvelavie == 0)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            jetesauvelavie++;
            await Task.Delay(1000);
        }
        else if (jetesauvelavie == 1)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.green;
            jetesauvelavie++;
            await Task.Delay(1000);
        }
        else if (jetesauvelavie == 2)
        {
            _playerInputManager.playerPrefab.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
            jetesauvelavie++;
            await Task.Delay(1000);
        }
    }
}
