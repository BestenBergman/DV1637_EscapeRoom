using NUnit.Framework;
using UnityEngine;

public class H_PlayerStats : MonoBehaviour
{
    [Tooltip("S�ger om spelaren holler i ett item eller inte")]
    public bool hasItem = false;

    [Tooltip("S�ger vart ett item placeras n�r man h�ller i det")]
    public Vector3 HoldPos = new Vector3(0, 0, 0);

    [Tooltip("S�ger vart ett item placeras n�r man inspekterar det")]
    public Vector3 InspectPos = new Vector3(0, 0, 0);

    [Tooltip("S�ger vilka tags som r�knas som items och d� kan plockas upp")]
    public string[] ItemTags = { "Item", "R1_Green", "R1_Red", "R1_Blue", "R4_BlueShard", "R4_RedShard", "R4_GreenShard" };

    [HideInInspector] public string[] ShardBoxes = { "R4_BlueBox", "R4_RedBox", "R4_GreenBox" };
    [HideInInspector] public string[] Shards = { "R4_BlueShard", "R4_RedShard", "R4_GreenShard" };

    [Tooltip("Visar om man har �ppnat kistan och d� startat spelet")]
    public bool hasOpenedChest = false;

    [HideInInspector] public bool hasTeleported = false;

    [Tooltip("Om man �r inne i en keypad")]
    public bool inKeyPad = false;

    [Tooltip("Om man inspekterar n�got")]
    public bool isInspecting = false;

    [Tooltip("Om man �r i en cutscene")]
    public bool fWalk = false;
    [HideInInspector] public Vector3 fWalkDir = Vector3.zero;
    [HideInInspector] public Vector2 fLookDir = Vector2.zero;
}
