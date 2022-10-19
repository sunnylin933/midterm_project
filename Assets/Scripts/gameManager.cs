using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Animator sheetAnimator;

    public static gameManager instance;
    public AudioSource audioSource;
    public AudioClip complete;

    public static int currentDay = 0;
    public static float secondsPerDay = 180f;
    private float secondsPassed;

    public static int customerThreshhold = 3;
    public static int customerFailedThreshold = 3;
    public int customersSatisfied;
    public int customersAngered;
    private bool customerCompletePlayed;

    public bool homeworkComplete;
    private bool homeworkCompletePlayed;

    private void Awake()
    {
        instance = this;
        secondsPerDay = 180f;
        secondsPassed = 0;
        customersSatisfied = 0;
        customersAngered = 0;

    }

    void Start()
    {
        homeworkComplete = false;
        customerCompletePlayed = false;
        homeworkCompletePlayed = false;

        customerThreshhold = 3 + currentDay;
        if (customerThreshhold > 12)
        {
            customerThreshhold = 12;
        }

        customerFailedThreshold = 3 - Mathf.FloorToInt(currentDay / 3);
        if (customerFailedThreshold < 1)
        {
            customerFailedThreshold = 1;
        }

        homeworkScript.homeworkThreshold = 15f + (currentDay * 5f);
        if(homeworkScript.homeworkThreshold > 60f)
        {
            homeworkScript.homeworkThreshold = 60f;
        }

        secondsPerDay = 240 + (currentDay * 30f);
        if(secondsPerDay > 600)
        {
            secondsPerDay = 600;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            print("Viewing");
            if(sheetAnimator.GetBool("isViewing"))
            {
                playerMovement.instance.canMove = true;
                sheetAnimator.SetBool("isViewing", false);
            }
            else
            {
                playerMovement.instance.canMove = false;
                playerMovement.instance.walkingSFX.Stop();
                playerMovement.instance.bodyAnimator.SetBool("isMoving", false);
                sheetAnimator.SetBool("isViewing", true);
            }
        }

        if(customersAngered > customerFailedThreshold)
        {
            levelLoader.instance.LoadSpecificLevel(3);
        }

        if(customersSatisfied >= customerThreshhold)
        {
            if(!customerCompletePlayed)
            {
                audioSource.Play();
                customerCompletePlayed = true;
            }
                 
        }

        if(homeworkComplete)
        {
            if(!homeworkCompletePlayed)
            {
                audioSource.Play();
                homeworkCompletePlayed = true;
            }
        }

        secondsPassed += Time.deltaTime;
        if(secondsPassed > secondsPerDay)
        {
            if(customersSatisfied >= customerThreshhold && homeworkComplete)
            {
                levelLoader.instance.LoadSpecificLevel(2);
            }
            else
            {
                levelLoader.instance.LoadSpecificLevel(3);
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            print(currentDay + " is the current day.");
            print("There are " + secondsPerDay + " seconds in the day today.");
            print(secondsPassed + " seconds have passed.");
            print("The customer threshold is " + customerThreshhold);
            print(customersSatisfied + " customers have been satisfied.");
            print("The homework threshold is " + homeworkScript.homeworkThreshold);
              
        }
    }
}
