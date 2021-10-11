using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPauseMenu : MonoBehaviour
{
    public void Resume_Click()
    {
        gameObject.SetActive(false);   
    }

    public void Exit_Click()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
