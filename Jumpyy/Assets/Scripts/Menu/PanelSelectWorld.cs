
using UnityEngine;
using UnityEngine.UI;

public class PanelSelectWorld : MonoBehaviour
{
    [SerializeField] private GameObject next;
    [SerializeField] private TransitionAnimation transition;
    [SerializeField] private Button[] buttons;
    
    private int index;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("UnlockedWorld"))
        {
            PlayerPrefs.SetInt("UnlockedWorld", 1);
            PlayerPrefs.Save();
        }

        int unlockedWorld = PlayerPrefs.GetInt("UnlockedWorld");
        for (int i = 0; i < 6; i++)
        {
            if (i < unlockedWorld)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
    

    public void ButtonWorldSelect(Button button)
    {
        index = int.Parse(button.name.Substring(12, 1)) - 1;
        PlayerPrefs.SetInt("SelectedWorld", index + 1);
        PlayerPrefs.Save();

        gameObject.transform.localScale = Vector2.zero;

        transition.Play();
    }

    private void Update()
    {
        if (transition.isFinished)
        {
            next.SetActive(true);
        }
    }
}
