using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fontFix : MonoBehaviour
{
    public Font[] fonts;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
