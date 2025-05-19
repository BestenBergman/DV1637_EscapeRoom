using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script handles button interactions.
/// </summary>
public class T_BtnController : MonoBehaviour
{
    /// <summary>
    /// Loads scene by parameter value(scene name)
    /// </summary>
    /// <param name="sceneName"></param>
    public void OpenScene(string sceneName)
    {
        //Sets timescale
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Resumes the game by toggling the pause state.
    /// </summary>
    public void Resume()
    {
        T_PauseGame pause = transform.parent.parent.parent.GetComponent<T_PauseGame>();
        if (pause != null)
        {
            pause.PauseGame();
        }
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
