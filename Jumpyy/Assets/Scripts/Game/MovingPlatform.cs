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

    private float timeColliderRemoved = 0;
    private bool colliderRemoved = false;
    private BoxCollider2D collider;

    private void Start()
    {
        origin = transform.position;
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!((int)other.contacts[0].normal.y == -1))
        {
            collider.enabled = false;
            timeColliderRemoved = Time.time;
            colliderRemoved = true;
        }
    }

    public void Trigger()
    {
        collider.enabled = false;
        timeColliderRemoved = Time.time;
        colliderRemoved = true;
    }

    private void FixedUpdate()
    {
        if (Time.time - lastTimeCheck > 1)
        {
            if (Vector2.Distance(origin, transform.position) > maxDistance)
            {
                Destroy(gameObject);
            }

            lastTimeCheck = Time.time;
        }

        transform.Translate(velocity * Time.deltaTime);
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