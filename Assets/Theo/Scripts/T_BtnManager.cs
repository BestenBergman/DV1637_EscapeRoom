using UnityEngine;
using UnityEngine.SceneManagement;

public class T_BtnManager : MonoBehaviour
{
    /// <summary>
    /// Loads scene by parameter value
    /// </summary>
    /// <param name="sceneName"></param>
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
