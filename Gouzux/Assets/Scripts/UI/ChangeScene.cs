using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene Instance;

    private Scene m_Scene;
    private string sceneName;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChargeScene()
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; //arrête l'éditor
        Application.Quit();
    }

}
