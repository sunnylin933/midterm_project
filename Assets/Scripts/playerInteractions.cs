using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractions : MonoBehaviour
{
    public static playerInteractions instance;

    public bool holdingGrocery;
    public int groceryGoal = 1;
    private int groceryObtained;
    public GameObject spawner;

    public GameObject groceryGoalPost;
    public Animator leftAnimator;
    public Animator rightAnimator;

    public GameObject npc;
    public bool npcSatisfied;

    public AudioSource itemSFX;
    public AudioSource cashRegisterSFX;
    void Start()
    {
        instance = this;
        holdingGrocery = false;
        groceryObtained = 1;
        npcSatisfied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingGrocery)
        {
            leftAnimator.SetBool("isHolding", true);
            rightAnimator.SetBool("isHolding", true);
        }
        else
        {
            leftAnimator.SetBool("isHolding", false);
            rightAnimator.SetBool("isHolding", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grocery" && !holdingGrocery)
        {
            itemSFX.Play();
            holdingGrocery = true;
        }

        if (collision.tag == "Checkout" && holdingGrocery)
        {
            cashRegisterSFX.Play();
            holdingGrocery = false;
            groceryObtained++;
            npcSatisfied = true;
        }

    }
}
