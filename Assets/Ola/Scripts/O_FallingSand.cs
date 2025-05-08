using UnityEngine;

public class O_FallingSand : MonoBehaviour
{
    public Material sand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Color color = sand.color;
        color.a = 0.25f;
        sand.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = sand.color;
        color.a += 0.1f * Time.deltaTime;
        sand.color = color;
    }
}
