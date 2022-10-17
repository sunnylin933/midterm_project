using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdItem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = itemSpawn.instance.spawnObject.GetComponent<SpriteRenderer>().sprite;
        if(playerInteractions.instance.holdingGrocery)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            print("Holding");
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
