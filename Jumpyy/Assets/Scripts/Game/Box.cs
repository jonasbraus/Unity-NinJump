using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Animator anim;
    private int hitCount = 0;
    private float timeDiedBox = 0;
    private bool boxDied = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((int)other.contacts[0].normal.y == 1)
        {
            hitCount++;
            if (hitCount == 2)
            {
                if (item != null)
                {
                    GameObject instance = Instantiate(item);
                    instance.transform.position = transform.position;
                }
                anim.Play("BreakBox1");
                boxDied = true;
                timeDiedBox = Time.time;
            }
            else
            {
                anim.Play("HitBox1");
            }
        }
    }

    private void Update()
    {
        if (boxDied)
        {
            if (Time.time - timeDiedBox > .5f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void SetAnimationState(int state)
    {
        anim.SetInteger("Value", state);
    }
}
