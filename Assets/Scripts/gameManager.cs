using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int currentDay;
    public float secondsPerDay;
    private float secondsPassed;

    private void Awake()
    {
        instance = this;
        currentDay = 0;
        secondsPerDay = 180f;
        secondsPassed = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsPassed += Time.deltaTime;
    }
}
