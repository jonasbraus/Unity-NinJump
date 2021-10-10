using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointEnd : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            other.gameObject.GetComponent<Character>().RegisterCheckPoint(gameObject);
            GetComponent<Animator>().SetInteger("Value", 1);
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
