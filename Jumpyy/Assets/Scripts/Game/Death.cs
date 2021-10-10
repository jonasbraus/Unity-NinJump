using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            other.gameObject.GetComponent<Character>().GetDamage(3);
        }
    }
}
