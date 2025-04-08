using NUnit.Framework;
using UnityEngine;

public class H_PlayerStats : MonoBehaviour
{
    public bool hasItem = false;

    public Vector3 HoldPos = new Vector3(0, 0, 2);

    public string[] ItemTags = { "Item", "R1_Green", "R1_Red", "R1_Blue", "R4_BlueShard", "R4_RedShard", "R4_GreenShard" };
}
