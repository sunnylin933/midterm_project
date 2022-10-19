using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    private GameObject npcSpawner;
    private GameObject spawner;
    private GameObject player;

    private AudioSource audioSource;
    private Animator bodyAnim;
    private SpriteRenderer headRenderer;

    private float moveSpeed;
    
    public int npcState;
    public int desiredGrocery;
    public bool spawnGroceries;
    public float walkCounter;

    private bool conditionIssued;
    private float patience;
    private float patienceTimer;

    private Rigidbody2D rb;
    void Start()
    {
        npcSpawner = GameObject.Find("npcSpawner");
        spawner = GameObject.Find("Shelves");
        player = GameObject.Find("Player");

        audioSource = GetComponent<AudioSource>();
       
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        moveSpeed = 2f;
        walkCounter = 0;
        npcState = 0;
        patienceTimer = 0;
        patience = 60f - gameManager.currentDay*5f;
        if(patience < 35f)
        {
            patience = 35f;
        }
        conditionIssued = false;


        Animator[] allAnimators = GetComponentsInChildren<Animator>();
        for(int i = 0; i < allAnimators.Length; i++)
        {
            if (allAnimators[i].gameObject.name == "Body")
            {
                bodyAnim = allAnimators[i];
            }
        }

        SpriteRenderer[] allRenderers = GetComponentsInChildren<SpriteRenderer>();
        for(int i =0; i < allRenderers.Length; i++)
        {
            if (allRenderers[i].gameObject.name == "Head")
            {
                headRenderer = allRenderers[i];
            }
        }
        int randomHead = UnityEngine.Random.Range(0, npcSpawner.GetComponent<npcSpawn>().npcHeads.Length);
        headRenderer.sprite = npcSpawner.GetComponent<npcSpawn>().npcHeads[randomHead];
        print(randomHead);
        print("New Head");
    }

    void Update()
    {
        switch(npcState)
        {
            case 0: //Entering the Room

                walkCounter += Time.deltaTime;
                if (walkCounter < 8f)
                {
                    rb.velocity = new Vector2(moveSpeed, 0);
                }
                else if (walkCounter < 9.1f)
                {
                    rb.velocity = Vector2.zero;
                    rb.velocity = new Vector2(0, moveSpeed);
                }
                else if (walkCounter < 9.85f)
                {
                    rb.velocity = Vector2.zero;
                    rb.velocity = new Vector2(moveSpeed, 0);
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    npcState++;
                }
                break;

            case 1: //Arriving at the Counter
                bodyAnim.SetBool("isMoving", false);
                desiredGrocery = UnityEngine.Random.Range(0, spawner.GetComponent<itemSpawn>().shelves.Length);
                //desiredGrocery = 3;
                spawner.GetComponent<itemSpawn>().aisleNumber = desiredGrocery;
                print("Grocery Changed");
                switch (desiredGrocery)
                {
                    case 0:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery0;
                        break;
                    case 1:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery1;
                        break;
                    case 2:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery2;
                        break;
                    case 3:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery3;
                        break;
                    case 4:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery4;
                        break;
                    case 5:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery5;
                        break;
                    case 6:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery6;
                        break;
                    case 7:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery7;
                        break;
                    case 8:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery8;
                        break;
                    case 9:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery9;
                        break;
                    case 10:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery10;
                        break;
                    case 11:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery11;
                        break;
                    case 12:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery12;
                        break;
                    case 13:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery13;
                        break;
                    case 14:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery14;
                        break;
                    case 15:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery15;
                        break;
                    case 16:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery16;
                        break;
                    case 17:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery17;
                        break;
                    case 18:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery18;
                        break;
                    case 19:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery19;
                        break;
                    case 20:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery20;
                        break;
                    case 21:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery21;
                        break;
                    case 22:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery22;
                        break;
                    case 23:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery23;
                        break;
                    default:
                        break;
                }
                spawner.GetComponent<itemSpawn>().spawnGroceries = true;
                player.GetComponent<playerInteractions>().npcSatisfied = false;
                textBubble.instance.backgroundSpriteRenderer.enabled = true;
                textBubble.instance.iconSpriteRenderer.sprite = itemSpawn.instance.spawnObject.GetComponent<SpriteRenderer>().sprite;
                textBubble.instance.iconSpriteRenderer.enabled = true;
                npcState++;
                break;

            case 2:
                patienceTimer += Time.deltaTime;
                if(patienceTimer > patience && !conditionIssued)
                {

                    textBubble.instance.iconSpriteRenderer.sprite = textBubble.instance.angry;
                    GameObject[] item = GameObject.FindGameObjectsWithTag("Grocery");
                    if(item != null)
                    {
                        for(int i = 0; i < item.Length; i++)
                        {
                            Destroy(item[i]);
                        }
                    }
                    if(!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(textBubble.instance.angrySFX);
                    }
                    playerInteractions.instance.holdingGrocery = false;
                    if(!conditionIssued)
                    {
                        gameManager.instance.customersAngered++;
                        conditionIssued = true;
                    }
                    StartCoroutine(delayStart());
                }

                if (player.GetComponent<playerInteractions>().npcSatisfied)
                {
                    textBubble.instance.iconSpriteRenderer.sprite = textBubble.instance.happy;
                    if(!conditionIssued)
                    {
                        gameManager.instance.customersSatisfied++;
                        conditionIssued = true;
                    }
                    StartCoroutine(delayStart());
                }
                break;

            case 3: //Leaving
                textBubble.instance.backgroundSpriteRenderer.enabled = false;
                textBubble.instance.iconSpriteRenderer.enabled = false;
                transform.localScale = new Vector3(-1, 1, 1);
                bodyAnim.SetBool("isMoving", true);
                rb.velocity = new Vector2(-moveSpeed, 0);
                StartCoroutine(deleteNPC());
                break;

            default:
                break;
        }
    }

    private IEnumerator delayStart()
    {
        yield return new WaitForSeconds(1);
        if(npcState == 2)
        {
            npcState++;
        }
    }

    private IEnumerator deleteNPC()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
