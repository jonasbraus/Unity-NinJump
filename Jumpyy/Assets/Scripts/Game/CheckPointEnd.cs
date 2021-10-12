using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointEnd : MonoBehaviour
{
    private float timeGameEnded = 0;
    private bool gameEnded = false;
    public int neededAppleCount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Character>())
        {
            Character player = other.gameObject.GetComponent<Character>();
            player.RegisterCheckPoint(gameObject);
            if (player.applesCount >= neededAppleCount)
            {
                player.canMove = false;
                GetComponent<Animator>().SetInteger("Value", 1);

                timeGameEnded = Time.time;
                gameEnded = true;
            
                int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevelWorld" + PlayerPrefs.GetInt("SelectedWorld"));

                if (unlockedLevel < 6)
                {
                    if(PlayerPrefs.GetInt("SelectedLevel") == unlockedLevel)
                    {
                        PlayerPrefs.SetInt("UnlockedLevelWorld" + PlayerPrefs.GetInt("SelectedWorld"), PlayerPrefs.GetInt("SelectedLevel") + 1);
                    }
                }
                else if (unlockedLevel == 6)
                {
                
                    int unlockedWorld = PlayerPrefs.GetInt("UnlockedWorld");
                    if (unlockedWorld < 6)
                    {
                        if(PlayerPrefs.GetInt("SelectedWorld") == unlockedLevel)
                        {
                            PlayerPrefs.SetInt("UnlockedWorld", PlayerPrefs.GetInt("SelectedWorld"));
                        }
                    }
                }
            
                PlayerPrefs.Save();   
            }
        }
    }

    private void Update()
    {
        if (gameEnded)
        {
            if (Time.time - timeGameEnded > 5)
            {
                SceneManager.LoadScene("StartMenu");
            }
        }
    }
}
