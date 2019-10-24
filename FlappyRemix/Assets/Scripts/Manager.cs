using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public TextMeshPro best;
   
    // Start is called before the first frame update
    void Start()
    {
        best.text = "Best: " + PlayerPrefs.GetInt("PersonalBest").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdMovement.score > PlayerPrefs.GetInt("PersonalBest", BirdMovement.score))
        {
            PlayerPrefs.SetInt("PersonalBest", BirdMovement.score);
            best.text = "Best: " + PlayerPrefs.GetInt("PersonalBest", BirdMovement.score).ToString();
        }


    }

}
