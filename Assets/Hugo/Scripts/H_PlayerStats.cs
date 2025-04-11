using NUnit.Framework;
using UnityEngine;

public class H_PlayerStats : MonoBehaviour
{
    [Tooltip("S�ger om spelaren holler i ett item eller inte")]
    public bool hasItem = false;

    [Tooltip("S�ger vart ett item placeras n�r man holler i det")]
    public Vector3 HoldPos = new Vector3(0, 0, 0);

    [Tooltip("S�ger vilka tags som r�knas som items och d� kan plockas upp")]
    public string[] ItemTags = { "Item", "R1_Green", "R1_Red", "R1_Blue", "R4_BlueShard", "R4_RedShard", "R4_GreenShard" };

    [HideInInspector] public string[] ShardBoxes = { "R4_BlueBox", "R4_RedBox", "R4_GreenBox" };
    [HideInInspector] public string[] Shards = { "R4_BlueShard", "R4_RedShard", "R4_GreenShard" };
}
