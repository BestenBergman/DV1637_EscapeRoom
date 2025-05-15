using UnityEngine;

public class O_PusselEttCheck : MonoBehaviour
{
    public GameObject greenCube;
    public GameObject blueCube;
    public GameObject redCube;
    public bool pusselEttComplete = false;


    void Update()
    {
        if (!pusselEttComplete)
        {
            PusselEttCheck();
        }
    }


    /// <summary>
    /// Saves bool-variables from the three different cubes, checks if all are correct and if so, changes complete to true.
    /// </summary>
    public void PusselEttCheck()
    {
        bool greenCheck = greenCube.GetComponent<O_PusselEtt>().placedCorrectly;
        bool blueCheck = blueCube.GetComponent<O_PusselEtt>().placedCorrectly;
        bool redCheck = redCube.GetComponent<O_PusselEtt>().placedCorrectly;
        if (greenCheck && blueCheck && redCheck)
        {
            pusselEttComplete = true;
        }
    }
}
