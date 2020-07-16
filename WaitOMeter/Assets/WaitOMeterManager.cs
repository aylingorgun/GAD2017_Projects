using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitOMeterManager : MonoBehaviour
{
    public TextMeshProUGUI best;
    public TextMeshProUGUI waiting;

    bool timerFlag = false;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        waiting.text = "Are you ready to wait ?...";
        best.text = PlayerPrefs.GetInt("PersonalBest").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerFlag)
        {
            timer += Time.deltaTime;
            waiting.text = "You are waiting for: " + (int)timer;
        }

        if (timer > PlayerPrefs.GetInt("PersonalBest", (int)timer))
        {
            PlayerPrefs.SetInt("PersonalBest", (int)timer);
            best.text = PlayerPrefs.GetInt("PersonalBest", (int)timer).ToString();
        }
            


    }

    public void OnReset()
    {
        timer = 0;
        PlayerPrefs.SetInt("PersonalBest", (int)timer);
        best.text = 0.ToString();
    }

    public void OnWait()
    {
        timer = 0;
        timerFlag = true;
    }

    public void OnEnough()
    {
        waiting.text = "Thanks for waiting:" + timer;
        timerFlag = false;
    }
}
