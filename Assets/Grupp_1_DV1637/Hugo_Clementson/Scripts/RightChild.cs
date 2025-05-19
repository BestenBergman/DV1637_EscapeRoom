using UnityEngine;
using UnityEngine.UIElements;

public class RightChild : MonoBehaviour
{
    [Tooltip("Den tag som letas efter")]
    public string wantedTag;

    /// <summary>
    /// Checks if its child has the right tag 
    /// </summary>
    /// <returns>true or false</returns>
    public bool HasRightChild()
    {
        if (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            if (child.tag == wantedTag)
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
