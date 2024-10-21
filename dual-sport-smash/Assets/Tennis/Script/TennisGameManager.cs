using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TennisGameManager : MonoBehaviour
{
    public int homeScore, awayScore, homePoint, awayPoint;
    public TextMeshProUGUI homeScoreText, awayScoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameoverText;

    public PlayerController playerController;
    public InGameStats Setup;

    private bool isWin;

    public int streakGoal;
    private bool isStreak;

    private void Start()
    {
        playerController.smoothSpeed = Setup.awayTennisMovement;
        
        homeScore = 0;
        awayScore = 0;
        homePoint = 0;
        awayPoint = 0;
        gameOverPanel.SetActive(false);

        isWin = true;

        isStreak = false;
    }

    private void Update()
    {
        if(homePoint > 45)
        {
            homeScore += 1;
            homePoint = 0;
            awayPoint = 0;
        }

        if (awayPoint > 45)
        {
            awayScore += 1;
            homePoint = 0;
            awayPoint = 0;
        }

        if (homeScore > 6)
        {
            Debug.Log("You Win");
            gameoverText.text = "YOU WIN!";
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;

            isWin = true;
        }
        else if (awayScore > 6)
        {
            Debug.Log("You Lose");
            gameoverText.text = "YOU LOSE!";
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        homeScoreText.text = homeScore + " - " + homePoint;
        awayScoreText.text = awayScore + " - " + awayPoint;

        if(streakGoal >= 5)
        {
            isStreak = true;
        }
    }

    public void HomeButtom()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

        if(isWin)
        {
            AchievementManager.instance.AddAchievementProgress("King of Tennis", 1);
            AchievementManager.instance.Unlock("First Winner");
        }

        if(isWin && awayScore <= 0)
        {
            AchievementManager.instance.Unlock("EZ Game");
        }

        if(isStreak)
        {
            AchievementManager.instance.Unlock("Tennis Streak");
        }
    }
}
