using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMoving : MonoBehaviour
{
    [SerializeField] private float offset;
    private Vector2 velocity = Vector2.left;
    private float speed = 3;
    private float originalX;

    private void Start()
    {
        originalX = transform.position.x;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            other.gameObject.GetComponent<Character>().GetDamage(.5f);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.contacts[0].normal * -3, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= originalX - offset || transform.position.x >= originalX + offset)
        {
            velocity.x *= -1;
        }
        transform.Translate(velocity * speed * Time.deltaTime);
    }
}
