using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    public static itemSpawn instance;

    //im sorry your gonna see this shit a lot in this script
    public GameObject[] aisleZero;
    public GameObject[] aisleOne; 
    public GameObject[] aisleTwo;
    public GameObject[] aisleThree;
    public GameObject[] aisleFour;
    public GameObject[] aisleFive;
    public GameObject[] aisleSix;
    public GameObject[] aisleSeven;
    public GameObject[] aisleEight;
    public GameObject[] aisleNine;
    public GameObject[] aisleTen;
    public GameObject[] aisleEleven;
    public GameObject[] aisleTwelve;
    public GameObject[] aisleThirteen;
    public GameObject[] aisleFourteen;
    public GameObject[] aisleFifteen;
    public GameObject[] aisleSixteen;
    public GameObject[] aisleSeventeen;
    public GameObject[] aisleEightteen;
    public GameObject[] aisleNineteen;
    public GameObject[] aisleTwenty;
    public GameObject[] aisleTwentyOne;
    public GameObject[] aisleTwentyTwo;
    public GameObject[] aisleTwentyThree;


    public GameObject[][] shelves = new GameObject[24][];

    public GameObject grocery0;
    public GameObject grocery1;
    public GameObject grocery2;
    public GameObject grocery3;
    public GameObject grocery4;
    public GameObject grocery5;
    public GameObject grocery6;
    public GameObject grocery7;
    public GameObject grocery8;
    public GameObject grocery9;
    public GameObject grocery10;
    public GameObject grocery11;
    public GameObject grocery12;
    public GameObject grocery13;
    public GameObject grocery14;
    public GameObject grocery15;
    public GameObject grocery16;
    public GameObject grocery17;
    public GameObject grocery18;
    public GameObject grocery19;
    public GameObject grocery20;
    public GameObject grocery21;
    public GameObject grocery22;
    public GameObject grocery23;

    public int aisleNumber = 0;
    public GameObject spawnObject;

    public bool spawnGroceries = false;
    public int numGroceries = 1;
    void Start()
    {
        instance = this;
        shelves[0] = aisleZero;
        shelves[1] = aisleOne;
        shelves[2] = aisleTwo;
        shelves[3] = aisleThree;
        shelves[4] = aisleFour;
        shelves[5] = aisleFive;
        shelves[6] = aisleSix;
        shelves[7] = aisleSeven;
        shelves[8] = aisleEight;
        shelves[9] = aisleNine;
        shelves[10] = aisleTen;
        shelves[11] = aisleEleven;
        shelves[12] = aisleTwelve;
        shelves[13] = aisleThirteen;
        shelves[14] = aisleFourteen;
        shelves[15] = aisleFifteen;
        shelves[16] = aisleSixteen;
        shelves[17] = aisleSeventeen;
        shelves[18] = aisleEightteen;
        shelves[19] = aisleNineteen;
        shelves[20] = aisleTwenty;
        shelves[21] = aisleTwentyOne;
        shelves[22] = aisleTwentyTwo;
        shelves[23] = aisleTwentyThree;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnGroceries)
        {
            for (int i = 0; i < numGroceries; i++)
            {
                int shelfNumber = Random.Range(0, shelves[aisleNumber].Length);
                Instantiate(spawnObject, shelves[aisleNumber][shelfNumber].transform.position, spawnObject.transform.rotation);
                print("Grocery Spawned");
            }
            spawnGroceries = false;
        }

    }
}
