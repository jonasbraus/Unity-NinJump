using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool invisible = false;
    public ItemType itemType;
    private bool died = false;
    private float timeDied = 0;
    private SpriteRenderer renderer;
    
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (invisible)
        {
            renderer.color = Color.clear;
        }
    }
    
    public void Trigger()
    {
        if(!invisible)
        {
            Destroy(GetComponent<CircleCollider2D>());
            GetComponent<Animator>().SetInteger("Value", 1);
            died = true;
            timeDied = Time.time;
        }

        renderer.color = Color.white;
        invisible = false;
    }

    private void Update()
    {
        if (died)
        {
            if (Time.time - timeDied > .5f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

public enum ItemType
{
    Apple, Banana, Cherry, Kiwi, Melon, Orange, Pineapple, Strawberry
    
}
