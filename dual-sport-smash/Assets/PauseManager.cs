using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
