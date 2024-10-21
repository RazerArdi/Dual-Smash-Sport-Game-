using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutPlayerTrigger : MonoBehaviour
{
    public bool isHomePlayer;
    public TennisGameManager gameManager;
    public BallController ballController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if(isHomePlayer)
            {
                gameManager.awayPoint += 15;
                ballController.AwayService();
            }
            else
            {
                gameManager.homePoint += 15;
                ballController.HomeService();   
            }
        }
    }
}
