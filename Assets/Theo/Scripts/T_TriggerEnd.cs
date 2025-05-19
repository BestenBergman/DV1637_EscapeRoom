using UnityEngine;


/// <summary>
/// This class handles when the player enters a collider and ends the game.
/// </summary>
public class T_TriggerEnd : MonoBehaviour
{
    // Bool variable that indicates if the game is won.
    public bool Win = false;

    // Reference to the UI GameObject that contains the T_HourglassTimer component.
    public GameObject UI;

    private T_HourglassTimer hourglassTimer;

    private void Start()
    {
        hourglassTimer = UI.GetComponent<T_HourglassTimer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Stops the hourglass timer.
        hourglassTimer.startTimer = false;

        //Sets win to true game has been won.
        Win = true;
    }

}
