using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeworkScript : MonoBehaviour
{
    public bool finishedHomework;

    public Sprite[] sprites;
    private bool working;
    private int currentSprite;
    private SpriteRenderer sprite;
    private float homeworkCounter;
    public static float homeworkThreshold = 15f;

    public AudioSource writingSFX;

    // Start is called before the first frame update
    void Start()
    {
        finishedHomework = false;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        homeworkCounter = 0;
        working = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sprite.sprite == sprites[4])
        {
            gameManager.instance.homeworkComplete = true;
            finishedHomework = true;
        }

        if (!finishedHomework && working)
        {
            homeworkCounter += Time.deltaTime;
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
        if(!finishedHomework && !playerInteractions.instance.holdingGrocery)
        {
            writingSFX.Play();
            working = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        writingSFX.Stop();
        working = false;
    }
}
