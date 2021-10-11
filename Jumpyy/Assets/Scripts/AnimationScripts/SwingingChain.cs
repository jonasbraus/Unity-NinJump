using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingChain : MonoBehaviour
{
    private float angularVelocity = 1;
    [SerializeField] private float speed;
    
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1), angularVelocity * Time.deltaTime * speed);

        float rotation = transform.localRotation.eulerAngles.z;
        
        if (rotation > 80 && rotation < 90)
        {
            angularVelocity *= -1;
        }
        else if (rotation < 280 && rotation > 270)
        {
            angularVelocity *= -1;
        }
    }
}
