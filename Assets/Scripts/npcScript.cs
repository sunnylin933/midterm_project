using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    private GameObject spawner;
    private GameObject player;

    public float moveSpeed = 2;
    
    public int npcState;
    public int desiredGrocery;
    public bool spawnGroceries;
    public float walkCounter;

    private Rigidbody2D rb;
    void Start()
    {
        spawner = GameObject.Find("Shelves");
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        walkCounter = 0;
        npcState = 0;
    }

    void Update()
    {
        switch(npcState)
        {
            case 0: //Entering the Room
                walkCounter += Time.deltaTime;
                if (walkCounter < 5.25f)
                {
                    rb.velocity = new Vector2(moveSpeed, 0);
                }
                else if (walkCounter < 6)
                {
                    rb.velocity = Vector2.zero;
                    rb.velocity = new Vector2(0, moveSpeed);
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    npcState++;
                }
                break;

            case 1: //Arriving at the Counter
                desiredGrocery = Random.Range(0, spawner.GetComponent<itemSpawn>().shelves.Length - 1);
                spawner.GetComponent<itemSpawn>().aisleNumber = desiredGrocery;
                print("Grocery Changed");
                switch (desiredGrocery)
                {
                    case 0:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery1;
                        break;
                    case 1:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery2;
                        break;
                    case 2:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery3;
                        break;
                    case 3:
                        spawner.GetComponent<itemSpawn>().spawnObject = spawner.GetComponent<itemSpawn>().grocery4;
                        break;
                    default:
                        break;
                }
                spawner.GetComponent<itemSpawn>().spawnGroceries = true;
                player.GetComponent<playerInteractions>().npcSatisfied = false;
                npcState++;
                break;

            case 2:
                if(player.GetComponent<playerInteractions>().npcSatisfied)
                {
                    StartCoroutine(delayStart());
                }
                break;

            case 3: //Leaving
                transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(-moveSpeed, 0);
                StartCoroutine(deleteNPC());
                break;

            default:
                break;
        }
    }

    private IEnumerator delayStart()
    {
        yield return new WaitForSeconds(2);
        print("NPC leaving");
        npcState++;
    }

    private IEnumerator deleteNPC()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
