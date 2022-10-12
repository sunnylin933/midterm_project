using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    public GameObject[] aisleOne; //fruits
    public GameObject[] aisleTwo;
    public GameObject[] aisleThree;
    public GameObject[] aisleFour;
    public GameObject[][] shelves = new GameObject[4][];

    public GameObject grocery1;
    public GameObject grocery2;
    public GameObject grocery3;
    public GameObject grocery4;

    public int aisleNumber = 0;
    public GameObject spawnObject;

    public bool spawnGroceries = false;
    public int numGroceries = 1;
    void Start()
    {
        shelves[0] = aisleOne;
        shelves[1] = aisleTwo;
        shelves[2] = aisleThree;
        shelves[3] = aisleFour;

    }

    // Update is called once per frame
    void Update()
    {
        if(spawnGroceries)
        {
            for (int i = 0; i < numGroceries; i++)
            {
                int shelfNumber = Random.Range(0, shelves[aisleNumber].Length - 1);
                Instantiate(spawnObject, shelves[aisleNumber][shelfNumber].transform.position, spawnObject.transform.rotation);
            }
            spawnGroceries = false;
        }

    }
}
