using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    
    public void Click()
    {
        pausePanel.SetActive(true);
    }
}
