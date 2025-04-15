using UnityEngine;

/// <summary>
/// A base manager that checks if all child components of type T meet a condition.
/// </summary>
public abstract class T_ManagerBase<T> : MonoBehaviour where T : Component
{
    // This stays true if it's true once.
    bool allConditionsMet = false;

    // Property
    public bool AllConditionsMet
    {
        get { return allConditionsMet; }
        set { allConditionsMet = value; }
    }


    void Update()
    {
        if (!AllConditionsMet && IsAllConditionsMet())
        {
            AllConditionsMet = true;
        }

        PrintOutResult(AllConditionsMet);
    }


    /// <summary>
    /// Prints out true or false if all conditions are met
    /// </summary>
    /// <param name="allCondition"></param>
    protected virtual void PrintOutResult(bool allCondition) 
    {
        if (allCondition)
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log("False");
        }
    }

    /// <summary>
    /// Override this to define what it means for a component to meet the condition.
    /// </summary>
    protected abstract bool IsConditionMet(T component);

    /// <summary>
    /// Checks if all relevant components under this manager meet the defined condition.
    /// </summary>
    private bool IsAllConditionsMet()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            T component = child.GetComponent<T>();
            if (component != null && !IsConditionMet(component))
            {
                return false;
            }
        }
        return true;
    }
}
