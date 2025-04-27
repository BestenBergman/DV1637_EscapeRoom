using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script handles basic button interactions.
/// </summary>
public class T_BtnController : MonoBehaviour
{
    /// <summary>
    /// Loads scene by parameter value(scene name)
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


    public void Resume()
    {
        T_PauseGame pause = transform.parent.parent.parent.GetComponent<T_PauseGame>();
        if(pause != null)
        {
            pause.PauseGame();
        }

        //Debug.Log("Pause component found: " + (pause != null));
    }

}
