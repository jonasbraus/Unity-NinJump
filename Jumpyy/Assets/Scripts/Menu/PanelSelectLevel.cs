using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelSelectLevel : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    
    private int index;

    private void Start()
    {
        int selectedWorld = PlayerPrefs.GetInt("SelectedWorld");
        if (!PlayerPrefs.HasKey("UnlockedLevelWorld" + selectedWorld))
        {
            PlayerPrefs.SetInt("UnlockedLevelWorld" + selectedWorld, 1);
            PlayerPrefs.Save();
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevelWorld" + selectedWorld);
        for (int i = 0; i < 6; i++)
        {
            if (i < unlockedLevel)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
    
    public void ButtonLevelSelect(Button button)
    {
        index = int.Parse(button.name.Substring(12, 1)) - 1;
        PlayerPrefs.SetInt("SelectedLevel", index);
        PlayerPrefs.Save();
        
        SceneManager.LoadScene("Level" + (index + 1) + "World" + (PlayerPrefs.GetInt("SelectedWorld") + 1),
            LoadSceneMode.Single);
    }
}
