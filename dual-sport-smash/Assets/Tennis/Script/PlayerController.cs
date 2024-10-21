using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public bool isAI;

    public MoveTennisHandler moveRight;
    public MoveTennisHandler moveLeft;
    
    public float speed;
    public GameObject sprite;
    public Animator anim;
    private Vector3 movement;
    public GameObject racket;
    public Button shotButton;

    [Header("AI")]
    public GameObject Ball;
    public float smoothSpeed;

    Vector3 previousPosition;

    void Start()
    {
        racket.SetActive(false);

        previousPosition = transform.position;
    }

    void Update()
    {
        if(!isAI)
        {
            if (Input.GetKey(KeyCode.S) || moveRight.isButtonHoldRight)
            {
                movement = new Vector3(0f, -1, 0f) * speed * Time.deltaTime;
                sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, 15f, sprite.transform.localScale.z);
                //anim.gameObject.transform.rotation = Quaternion.Euler(0, 0, -30);
                anim.Play("run");
            }
            else if (Input.GetKey(KeyCode.W) || moveLeft.isButtonHoldLeft)
            {
                movement = new Vector3(0f, 1, 0f) * speed * Time.deltaTime;
                sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, -15f, sprite.transform.localScale.z);
                //anim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 30);
                anim.Play("run");
            }
            else
            {
                movement = new Vector3(0f, 0, 0f);
                sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, sprite.transform.localScale.y, sprite.transform.localScale.z);
                //anim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 30);
                anim.Play("idle");
            }

            transform.Translate(movement);
        }
        else
        {
            Vector3 preMovePosition = transform.position;

            // Lakukan pergerakan seperti yang Anda lakukan dalam kode Anda
            Vector3 targetPosition = Ball.transform.position;
            targetPosition.x = transform.position.x;
            targetPosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            // Bandingkan posisi sebelum dan sesudah pergerakan
            if (preMovePosition != transform.position)
            {
                // Objek sedang bergerak
                Debug.Log("Objek bergerak!");
                anim.Play("run");
            }
            else
            {
                // Objek tidak bergerak
                Debug.Log("Objek tidak bergerak.");
                anim.Play("idle");
            }

            // Perbarui posisi sebelumnya untuk iterasi berikutnya
            previousPosition = transform.position;
        }
    }

    public void ShotButton()
    {
        StartCoroutine(ShotDelay(0.5f));
    }

    private IEnumerator ShotDelay(float delay)
    {
        racket.SetActive(true);
        shotButton.interactable = false;
        yield return new WaitForSeconds(delay);
        racket.SetActive(false);
        shotButton.interactable = true;
    }
}
