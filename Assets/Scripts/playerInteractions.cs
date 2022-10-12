using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractions : MonoBehaviour
{
    public bool holdingGrocery;
    public int groceryGoal = 1;
    private int groceryObtained;
    public GameObject spawner;

    public GameObject groceryGoalPost;
    public Animator leftAnimator;
    public Animator rightAnimator;

    public GameObject npc;
    public bool npcSatisfied;
    void Start()
    {
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
        if (collision.tag == "Grocery")
        {
            holdingGrocery = true;
        }

        if (collision.tag == "Checkout" && holdingGrocery)
        {
            holdingGrocery = false;
            groceryObtained++;
            npcSatisfied = true;
        }

    }
}
