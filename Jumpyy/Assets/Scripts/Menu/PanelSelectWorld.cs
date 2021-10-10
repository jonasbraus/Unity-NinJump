using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelSelectWorld : MonoBehaviour
{
    [SerializeField] private GameObject[] arraysNext;
    [SerializeField] private TransitionAnimation transition;
    private int index;

    public void ButtonWorldSelect(Button button)
    {
        index = int.Parse(button.name.Substring(12, 1)) - 1;

        transition.Play();
    }

    private void Update()
    {
        if (transition.isEndingFinished)
        {
            switch (index)
            {
                case 0:
                    SceneManager.LoadScene("Level1", LoadSceneMode.Single);
                    break;
            }
        }
    }
}
