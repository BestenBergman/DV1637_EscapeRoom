using UnityEngine;

public class O_PusselEttCheck : MonoBehaviour
{
    public GameObject greenCube;
    public GameObject blueCube;
    public GameObject redCube;
    public bool pusselEttComplete = false;


   
    void Start()
    {
        
    }

    void Update()
    {
        if (!pusselEttComplete)
        {
            PusselEttCheck();
        }
    }

    public void PusselEttCheck()
    {
        // Saves bool-variables from the three different cubes, checks if all are correct and if so, changes complete to true.
        bool greenCheck = greenCube.GetComponent<O_PusselEtt>().placedCorrectly;
        bool blueCheck = blueCube.GetComponent<O_PusselEtt>().placedCorrectly;
        bool redCheck = redCube.GetComponent<O_PusselEtt>().placedCorrectly;
        if (greenCheck && blueCheck && redCheck)
        {
            pusselEttComplete = true;
        }
        

    }
}
