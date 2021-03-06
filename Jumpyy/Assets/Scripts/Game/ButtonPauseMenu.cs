using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPauseMenu : MonoBehaviour
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
        }
    }
    
    public void Resume_Click()
    {
        player.canMove = true;
        gameObject.SetActive(false);   
    }

    public void Exit_Click()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
