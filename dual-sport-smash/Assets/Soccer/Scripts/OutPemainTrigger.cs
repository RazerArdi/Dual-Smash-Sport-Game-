using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutPemainTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pemain")
        {
            GameManager.Instance.ResetBallAndPlayers();
        }
    }
}
