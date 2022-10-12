using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeworkScript : MonoBehaviour
{
    public Sprite[] sprites;
    private bool working;
    private int currentSprite;
    private SpriteRenderer sprite;
    private float homeworkCounter;
    public float homeworkThreshold;

    private bool finished;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        homeworkCounter = 0;
        finished = false;
        working = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sprite.sprite == sprites[4])
        {
            finished = true;
        }

        if (!finished && working)
        {
            homeworkCounter += Time.deltaTime;
            print(homeworkCounter);
            if (homeworkCounter > homeworkThreshold)
            {
                currentSprite++;
                sprite.sprite = sprites[currentSprite];
                homeworkCounter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        working = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        working = false;
    }
}
