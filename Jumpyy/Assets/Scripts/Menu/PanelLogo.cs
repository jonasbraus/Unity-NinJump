using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLogo : MonoBehaviour
{
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private TransitionAnimation transition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
            gameObject.transform.localScale = new Vector2();
            transition.Play();
        }

        if (transition.isFinished)
        {
            nextPanel.SetActive(true);
            transition.isFinished = false;
            gameObject.SetActive(false);
        }
    }
}
