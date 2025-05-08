using System.Threading;
using UnityEngine;

public class O_FallingSand : MonoBehaviour
{
    public Material sand;
    private float timer;
    public ParticleSystem fsps;
    float amountOfSand = 5f;
    float startEm = 1f;
    bool sandStarted = false;
    bool firstIncrease = false;
    bool secondIncrease = false;
    [HideInInspector] public H_PlayerStats ps;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<H_PlayerStats>();
        var emission = fsps.emission;
        emission.rateOverTime = 0f;
        Color color = sand.color;
        color.a = 0.2f;
        sand.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (ps.hasOpenedChest && !sandStarted)
        {
            var emission = fsps.emission;
            emission.rateOverTime = startEm;
            sandStarted = true;
        }
        else if (timer > 5f && !firstIncrease)
        {
            Color color = sand.color;
            color.a += 0.1f * Time.deltaTime;
            sand.color = color;
            firstIncrease = true;
        }
        else if(timer > 20f && !secondIncrease)
        {
            var emission = fsps.emission;
            emission.rateOverTime = amountOfSand;
            secondIncrease = true;
        }
    }
}
