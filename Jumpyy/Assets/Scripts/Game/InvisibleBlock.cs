using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    private SpriteRenderer renderer;
    
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.clear;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if((int)other.contacts[0].normal.y == 1)
        {
            renderer.color = Color.white;
        }
    }
}
