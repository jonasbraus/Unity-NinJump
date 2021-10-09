using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimation : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isGrowing = true;
    private bool isPlaying = false;

    public bool isEndingFinished
    {
        get
        {
            return isGrowing;
        }
    }

    public bool isFinished = false;

    public void Play()
    {
        transform.localScale = new Vector2(0, 0);
        isGrowing = true;
        isPlaying = true;
    }

    public void PlayOpening()
    {
        isGrowing = true;
        transform.localScale = new Vector2(50, 50);
        isPlaying = true;
    }

    private void Update()
    {
        if(isPlaying)
        {
            if (transform.localScale.x >= 50)
            {
                isGrowing = false;
            }

            if (isGrowing)
            {
                transform.localScale += (Vector3)new Vector2(speed * Time.deltaTime, speed * Time.deltaTime);
            }
            else
            {
                transform.localScale -= (Vector3)new Vector2(speed * Time.deltaTime, speed * Time.deltaTime);
            }
            
            if(transform.localScale.y <= 0)
            {
                isPlaying = false;
                transform.localScale = new Vector2();
                isFinished = true;
            }
        }
    }
}
