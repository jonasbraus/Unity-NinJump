using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupLoader : MonoBehaviour
{
    [SerializeField] private TransitionAnimation transition;
    [SerializeField] private GameObject overlay;
    
    private void Start()
    {
        overlay.SetActive(false);
        
        switch (PlayerPrefs.GetInt("SelectedCharacter"))
        {
            case 0:
                
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
        
        transition.PlayOpening();
    }

    private void Update()
    {
        if (transition.isFinished)
        {
            overlay.SetActive(true);
            transition.isFinished = false;
        }
    }
}
