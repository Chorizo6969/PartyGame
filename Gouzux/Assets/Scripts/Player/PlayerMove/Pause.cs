using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    [SerializeField]
    private GameObject _pauseMenu;

    public void OnPause(InputAction.CallbackContext callbackContext)
    {
        //N'importe quel joueur...
        _playerInput.SwitchCurrentActionMap("UI");
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnEndPause()
    {
        _playerInput.SwitchCurrentActionMap("Game");
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
