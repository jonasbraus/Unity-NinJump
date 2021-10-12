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
    private BoxCollider2D collider;
    
    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
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
            collider.enabled = false;
            timeColliderRemoved = Time.time;
            colliderRemoved = true;
        }
    }

    public void Trigger()
    {
        if(!activated)
        {
            collider.enabled = false;
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
                collider.enabled = true;
                colliderRemoved = false;
            }
        }
    }
}
