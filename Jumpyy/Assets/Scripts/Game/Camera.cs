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
            case 3:
                player = GameObject.Find("VirtualGuy(Clone)");
                break;
        }
    }

    private void Update()
    {
        Vector3 position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
}
