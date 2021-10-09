using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCharacterSelect : MonoBehaviour
{
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private TransitionAnimation transition;

    public void ButtonMaskDude()
    {
        SaveSelectedCharacter(0);
    }

    public void ButtonNinjaFrog()
    {
        SaveSelectedCharacter(1);
    }

    public void ButtonPinkMan()
    {
        SaveSelectedCharacter(2);
    }

    public void ButtonVirtualGuy()
    {
        SaveSelectedCharacter(3);
    }

    private void SaveSelectedCharacter(int characterID)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterID);
        PlayerPrefs.Save();
        
        gameObject.transform.localScale = new Vector2();
        transition.Play();
    }

    private void Update()
    {
        if (transition.isFinished)
        {
            nextPanel.SetActive(true);
            transition.isFinished = false;
            gameObject.SetActive(false);
        }
    }
}
