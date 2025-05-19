using UnityEngine;

public class H_ItemSpawn : MonoBehaviour
{
    [HideInInspector] public Vector3 spawnPosition;

    private void Awake()
    {
        spawnPosition = transform.position;
    }
}
