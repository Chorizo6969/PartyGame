using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scrit qui g�re les changement de sc�ne
/// </summary>
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

    /// <summary>
    /// Charge une sc�ne voulu
    /// </summary>
    /// <param name="sceneIndex">L'index de la sc�ne visible dans le build setting</param>
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Charge la scene actuel
    /// </summary>
    public void ChargeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Quitte le build ou l'�diteur
    /// </summary>
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; //arr�te l'�ditor
        Application.Quit();
    }

}
