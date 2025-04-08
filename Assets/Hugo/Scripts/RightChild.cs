using UnityEngine;
using UnityEngine.UIElements;

public class RightChild : MonoBehaviour
{
    public string wantedTag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool HasRightChild()
    {
        if (transform.childCount != 0)
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
