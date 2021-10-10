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
        }
    }

    private void Update()
    {
        Vector3 position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
}
