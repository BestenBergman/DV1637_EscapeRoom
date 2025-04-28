using UnityEngine;
using UnityEngine.SceneManagement;

public class T_PauseGame : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool pauseGame = false;

    private void Start()
    {
        pauseCanvas.SetActive(pauseGame);
    }

    void Update()
    {
        if (pauseCanvas != null)
        {
            if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)))
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseGame = !pauseGame; // Sets value to opposite value.

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
