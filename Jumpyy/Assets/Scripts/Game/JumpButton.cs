using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    private Character player;

    private void Start()
    {
        switch (PlayerPrefs.GetInt("SelectedCharacter"))
        {
            case 0:
                player = GameObject.Find("MaskDude(Clone)").GetComponent<Character>();
                break;
            case 1:
                player = GameObject.Find("NinjaFrog(Clone)").GetComponent<Character>();
                break;
            case 2:
                player = GameObject.Find("PinkMan(Clone)").GetComponent<Character>();
                break;
            case 3:
                player = GameObject.Find("VirtualGuy(Clone)").GetComponent<Character>();
                break;
        }
    }

    public void OnPointerDown(PointerEventData p)
    {
        player.RequestJump();
    }
    
}
