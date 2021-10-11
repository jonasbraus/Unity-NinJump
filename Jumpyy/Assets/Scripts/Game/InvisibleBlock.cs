using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    private SpriteRenderer renderer;
    private float timeColliderRemoved = 0;
    private bool colliderRemoved = false;
    private bool activated = false;
    
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1, 1, 1, .4f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if((int)other.contacts[0].normal.y == 1)
        {
            renderer.color = Color.white;
            activated = true;
        }
        else if(!activated)
        {
            Destroy(GetComponent<BoxCollider2D>());
            timeColliderRemoved = Time.time;
            colliderRemoved = true;
        }
    }

    private void Update()
    {
        
        if (colliderRemoved)
        {
            if (Time.time - timeColliderRemoved > 1f)
            {
                gameObject.AddComponent<BoxCollider2D>();
                colliderRemoved = false;
            }
        }
    }
}
