using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseScreen;

    private bool paused = false;

    void Start()
    {
        PauseScreen.SetActive(false);
    }


    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;

        }

        if(paused)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused) {

            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}