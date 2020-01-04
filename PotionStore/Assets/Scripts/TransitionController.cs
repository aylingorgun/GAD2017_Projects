using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{

    public GameObject go;
    public GameObject pause_panel;
    bool paused = false;

    private void Start()
    {
        pause_panel.SetActive(false);
        go.SetActive(true);
        Time.timeScale = 1;
        paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && paused == false)
        {
            pause_panel.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && paused == true)
        {
            pause_panel.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void Transition()
    {
        go.SetActive(false);
    }
}
