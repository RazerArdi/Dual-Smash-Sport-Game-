using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AchievenmentListIngame list;

    public InGameStats setup, easy, normal, hard;

    private void Start()
    {
        Time.timeScale = 1.0f;
        Destroy(GameObject.Find("Soccer - Main Camera"));
        Destroy(GameObject.Find("Light Manager"));
        Destroy(GameObject.Find("Pitch Manager"));
        Destroy(GameObject.Find("Soccer - Game Manager"));
        Destroy(GameObject.Find("Soccer - Ball"));
    }

    public void LoadToTennis(int difficulty)
    {
        SceneManager.LoadScene(1);
        if(difficulty == 1)
        {
            setup.awayTennisMovement = easy.awayTennisMovement;
        }
        else if(difficulty == 2)
        {
            setup.awayTennisMovement = normal.awayTennisMovement;
        }
        else if(difficulty == 3)
        {
            setup.awayTennisMovement = hard.awayTennisMovement;
        }
    }

    public void LoadToSoccer(int difficulty)
    {
        SceneManager.LoadScene("Preload");

        if (difficulty == 1)
        {
            setup.awaySoccerMovement = easy.awaySoccerMovement;
        }
        else if (difficulty == 2)
        {
            setup.awaySoccerMovement = normal.awaySoccerMovement;
        }
        else if (difficulty == 3)
        {
            setup.awaySoccerMovement = hard.awaySoccerMovement;
        }
    }

    public void LoadAchievement()
    {
        list.OpenWindow();
    }
}
