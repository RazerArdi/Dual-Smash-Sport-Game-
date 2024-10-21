using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject awayTeamWinsText;
    [SerializeField] private GameObject homeTeamWinsText;
    [SerializeField] private GameObject tieText;

    public bool isWin;
    public bool is5Goal;
    public bool is10Goal;
    
    public static GameOverManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }

    private void Update()
    {
        if (GameManager.Instance.awayTeam.score > GameManager.Instance.homeTeam.score)
        {
            awayTeamWinsText.SetActive(true);
            isWin = false;
        }
            
        else if (GameManager.Instance.awayTeam.score < GameManager.Instance.homeTeam.score)
        {
            homeTeamWinsText.SetActive(true);
            isWin = true;
        }
        else
        {
            tieText.SetActive(true);
            isWin = false;
        }

        if(GameManager.Instance.homeTeam.score >= 5)
        {
            is5Goal = true;

            if (GameManager.Instance.homeTeam.score >= 10)
            {
                is10Goal = true;
            }
            else
            {
                is10Goal = false;
            }
        }
        else
        {
            is5Goal = false;
        }
            
    }
}
