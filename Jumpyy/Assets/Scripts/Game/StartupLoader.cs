using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupLoader : MonoBehaviour
{
    [SerializeField] private TransitionAnimation transition;
    [SerializeField] private GameObject overlay;

    [SerializeField] private GameObject maskDude, ninjaFrog, pinkMan, virtualGuy;

    private void Awake()
    {
        switch (PlayerPrefs.GetInt("SelectedCharacter"))
        {
            case 0:
                Instantiate(maskDude);
                break;
            case 1:
                Instantiate(ninjaFrog);
                break;
            case 2:
                Instantiate(pinkMan);
                break;
            case 3:
                Instantiate(virtualGuy);
                break;
        }
    }

    private void Start()
    {
        overlay.SetActive(false);

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
