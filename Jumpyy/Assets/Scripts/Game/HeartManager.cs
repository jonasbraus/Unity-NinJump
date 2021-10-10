using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite[] heartSprites;

    private float lastTimeActiveAnimation = 0;
    
    public void UpdateHearts(float hp)
    {
        if (hp > 2.5f)
        {
            foreach (Image img in hearts)
            {
                img.sprite = heartSprites[0];
            }
        }
        else if (hp > 2)
        {
            hearts[0].sprite = heartSprites[1];
            hearts[1].sprite = heartSprites[0];
            hearts[2].sprite = heartSprites[0];
        }
        else if (hp > 1.5f)
        {
            hearts[0].sprite = heartSprites[2];
            hearts[1].sprite = heartSprites[0];
            hearts[2].sprite = heartSprites[0];
        }
        else if (hp > 1)
        {
            hearts[0].sprite = heartSprites[2];
            hearts[1].sprite = heartSprites[1];
            hearts[2].sprite = heartSprites[0];
        }
        else if (hp > .5f)
        {
            hearts[0].sprite = heartSprites[2];
            hearts[1].sprite = heartSprites[2];
            hearts[2].sprite = heartSprites[0];
        }
        else if (hp > 0)
        {
            hearts[0].sprite = heartSprites[2];
            hearts[1].sprite = heartSprites[2];
            hearts[2].sprite = heartSprites[1];
        }
        else
        {
            hearts[0].sprite = heartSprites[2];
            hearts[1].sprite = heartSprites[2];
            hearts[2].sprite = heartSprites[2];
        }

        foreach (Image img in hearts)
        {
            img.GetComponent<JumpingObject>().active = true;
            lastTimeActiveAnimation = Time.time;
        }
        
    }

    private void Update()
    {
        if (Time.time - lastTimeActiveAnimation > 1.2f)
        {
            foreach (Image img in hearts)
            {
                img.GetComponent<JumpingObject>().active = false;
            }
        }
    }
}
