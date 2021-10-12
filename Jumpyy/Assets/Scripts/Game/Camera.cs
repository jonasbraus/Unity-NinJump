using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        switch (PlayerPrefs.GetInt("SelectedCharacter"))
        {
            case 0:
                player = GameObject.Find("MaskDude(Clone)");
                break;
            case 1:
                player = GameObject.Find("NinjaFrog(Clone)");
                break;
            case 2:
                player = GameObject.Find("PinkMan(Clone)");
                break;
        }
    }

    private void Update()
    {
        int offsetY = (int)player.transform.position.y / 5;
        Vector3 position = new Vector3(player.transform.position.x, (offsetY * 4.8f) + .4f, transform.position.z);

        transform.position = position;
    }
}
