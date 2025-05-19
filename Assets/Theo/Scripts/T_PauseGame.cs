using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles pausing and unpausing the game, including toggling the pause UI and freezing gameplay.
/// </summary>
public class T_PauseGame : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool pauseGame = false;

    private void Start()
    {
        //Initialize pause state
        pauseCanvas.SetActive(pauseGame);
    }

    void Update()
    {
        if (pauseCanvas != null)
        {
            // Toggle pause state when P or ESC key is pressed.
            if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)))
            {
                PauseGame();
            }
        }
    }

    /// <summary>
    /// Toggles pause state and UI, and updates time and cursor settings.
    /// </summary>
    public void PauseGame()
    {
        // Toggle the pause state
        pauseGame = !pauseGame; // Sets value to opposite value.

        // Show or hide the pause UI
        pauseCanvas.SetActive(pauseGame);

        if (pauseGame)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
