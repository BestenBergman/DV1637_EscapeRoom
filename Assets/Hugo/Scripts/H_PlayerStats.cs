using NUnit.Framework;
using UnityEngine;

public class H_PlayerStats : MonoBehaviour
{
    [Tooltip("Säger om spelaren holler i ett item eller inte")]
    public bool hasItem = false;

    [Tooltip("Säger vart ett item placeras när man holler i det")]
    public Vector3 HoldPos = new Vector3(0, 0, 0);

    [Tooltip("Säger vilka tags som räknas som items och då kan plockas upp")]
    public string[] ItemTags = { "Item", "R1_Green", "R1_Red", "R1_Blue", "R4_BlueShard", "R4_RedShard", "R4_GreenShard" };

    [HideInInspector] public string[] ShardBoxes = { "R4_BlueBox", "R4_RedBox", "R4_GreenBox" };
    [HideInInspector] public string[] Shards = { "R4_BlueShard", "R4_RedShard", "R4_GreenShard" };
}
