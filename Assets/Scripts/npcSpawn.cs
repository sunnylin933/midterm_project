using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class npcSpawn : MonoBehaviour
{
    private float spawnCounter;
    public int spawnCount = 0;
    public int spawnDelay = 0;
    public bool spawning = true;
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawning)
        {
            spawnCounter += Time.deltaTime;
            if (spawnCounter > spawnDelay)
            {

                if (GameObject.Find("npcBlue(Clone)") == false)
                {
                    Instantiate(npc, transform.position, new Quaternion(0, 0, 0, 0));
                    spawnCounter = 0;
                }
                else
                {
                    spawnCounter = 0;
                }
            }
        }

    }
}
