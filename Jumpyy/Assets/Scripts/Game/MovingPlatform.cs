using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 velocity;
    public float maxDistance;

    private Vector2 origin;
    private float lastTimeCheck = 0;

    private void Start()
    {
        origin = transform.position;
    }

    private void FixedUpdate()
    {
        
        if(Time.time - lastTimeCheck > 1)
        {
            if (Vector2.Distance(origin, transform.position) > maxDistance)
            {
                Destroy(gameObject);
            }

            lastTimeCheck = Time.time;
        }
        
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
