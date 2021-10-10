using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObject : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float speed;
    public bool active = true;

    private Vector2 velocity = Vector2.up;

    private float defaultPositionY;

    private void Start()
    {
        defaultPositionY = transform.position.y;
    }
    
    private void Update()
    {
        if(active)
        {
            if (transform.position.y - defaultPositionY >= amplitude)
            {
                velocity = Vector2.down;
            }
            else if (transform.position.y - defaultPositionY <= 0)
            {
                velocity = Vector2.up;
            }

            transform.Translate(velocity * speed * Time.deltaTime);
        }
    }
}
