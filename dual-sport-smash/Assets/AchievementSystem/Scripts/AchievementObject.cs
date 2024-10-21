using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementObject : MonoBehaviour
{
    public GameObject[] objects;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }
        }
    }
}
