using System.Linq;
using TMPro;
using UnityEngine;

public class O_CheckForShardPopUp : MonoBehaviour
{
    public TextMeshProUGUI shardPopUp;
    [HideInInspector] public H_PlayerStats ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GetComponent<H_PlayerStats>();
    }

    // Update is called once per frame
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
