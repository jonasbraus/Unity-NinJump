using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float damage;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            other.gameObject.GetComponent<Character>().GetDamage(damage);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.contacts[0].normal * -3, ForceMode2D.Impulse);
        }
    }
}
