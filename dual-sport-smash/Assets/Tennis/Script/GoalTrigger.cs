using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public bool isHomePlayer;
    public TennisGameManager gameManager;
    public BallController ballController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (isHomePlayer)
            {
                gameManager.homePoint += 15;
                ballController.HomeService();
                gameManager.streakGoal += 1;
            }
            else
            {
                gameManager.awayPoint += 15;
                gameManager.streakGoal = 0;
                ballController.AwayService();
            }
        }
    }
}
