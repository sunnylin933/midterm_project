using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textBubble : MonoBehaviour
{
    public static textBubble instance;
    public Sprite angry;
    public Sprite happy;
    public AudioClip angrySFX;
    public AudioClip happySFX;

    public SpriteRenderer backgroundSpriteRenderer;
    public SpriteRenderer iconSpriteRenderer;

    private void Awake()
    {
        instance = this;
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        iconSpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        backgroundSpriteRenderer.enabled = false;
        iconSpriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
