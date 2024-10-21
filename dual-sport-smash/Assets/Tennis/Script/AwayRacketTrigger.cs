using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwayRacketTrigger : MonoBehaviour
{
    public GameObject racket;
    void Start()
    {
        racket.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            StartCoroutine(delayRacket(2f));
        }
    }
    private IEnumerator delayRacket(float  delay)
    {
        racket.SetActive(true);
        yield return new WaitForSeconds(delay);
        racket.SetActive(false);
    }
}
