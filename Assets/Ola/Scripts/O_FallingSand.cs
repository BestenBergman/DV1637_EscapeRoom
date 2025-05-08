using System.Threading;
using UnityEngine;

public class O_FallingSand : MonoBehaviour
{
    public Material sand;
    private float timer;
    public ParticleSystem fsps;
    float amountOfSand = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //var emission = fsps.emission;
        Color color = sand.color;
        color.a = 0.2f;
        sand.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var emission = fsps.emission;
        if (timer > 20)
        {
            emission.rateOverTime = amountOfSand;
            Color color = sand.color;
            color.a += 0.1f * Time.deltaTime;
            sand.color = color;
        }
    }
}
