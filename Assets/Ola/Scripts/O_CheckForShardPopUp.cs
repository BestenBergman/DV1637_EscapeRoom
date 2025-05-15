using System.Linq;
using TMPro;
using UnityEngine;

public class O_CheckForShardPopUp : MonoBehaviour
{
    [Tooltip("TextMeshPro that give hints about the shards")]
    public TextMeshProUGUI shardPopUp;
    [HideInInspector] public H_PlayerStats ps;
    
    
    void Start()
    {
        ps = GetComponent<H_PlayerStats>();
    }

    /// <summary>
    /// Pop-up text to that shows when
    /// inspecting a shard.
    /// </summary>
    void Update()
    {
        if (ps.isInspecting && ps.Shards.Contains(gameObject.transform.GetChild(0).transform.GetChild(1).tag))
        {
            shardPopUp.text = "This looks like something that can become useful later!";
        }
        else
        {
            shardPopUp.text = "";
        }
    }
}
