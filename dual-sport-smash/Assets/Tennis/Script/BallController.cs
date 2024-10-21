using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    public AudioSource pluit;
    public GameObject playerHome, playerAway;

    void Start()
    {
        StartCoroutine(Launch());
    }

    private IEnumerator Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        playerHome.transform.position = new Vector3(playerHome.transform.position.x, 0, playerHome.transform.position.z);
        playerAway.transform.position = new Vector3(playerAway.transform.position.x, 0, playerAway.transform.position.z);
        Debug.Log(x);
        yield return new WaitForSeconds(1.5f);
        pluit.Play();
        rb.velocity = new Vector3(speed * x, transform.position.y, transform.position.z);
    }

    public void HomeService()
    {
        StartCoroutine(service(1.5f, 1, false));
    }

    public void AwayService()
    {
        StartCoroutine(service(1.5f, -1, true));
    }

    private IEnumerator service(float delay, int player, bool isHome)
    {
        rb.velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(2.51f, 0, 0);
        if(isHome)
        {
            transform.position = new Vector3(36.3f, 0, 0);
        }
        else
        {
            transform.position = new Vector3(-30.9f, 0, 0);
        }
        playerHome.transform.position = new Vector3(playerHome.transform.position.x, 0, playerHome.transform.position.z);
        playerAway.transform.position = new Vector3(playerAway.transform.position.x, 0, playerAway.transform.position.z);
        yield return new WaitForSeconds(delay);
        pluit.Play();
        rb.velocity = new Vector3(speed * player, transform.position.y, transform.position.z);
    }
}
