using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    //public int numberOfPlatforms = 200;
    public float levelWidth = 1.5f;
    public float minY = .5f;
    public float maxY = 1f;

    Vector3 spawnPosition;

    public GameObject pause_panel;
    public static bool paused = false;

    // Use this for initialization
    private void Start()
    {
        spawnPosition = new Vector3();
        //int i = 0; i < numberOfPlatforms; i++

        pause_panel.SetActive(false);
        Time.timeScale = 1;
        paused = false;

    }



    void Update()
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

        while (Platform.colliderCheck == true)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            //Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            GameObject platformPrefab = ObjectPooler.SharedInstance.GetPooledObject(0);
            platformPrefab.SetActive(true);
            platformPrefab.transform.position = spawnPosition;
            platformPrefab.transform.rotation = Quaternion.identity;
            Platform.colliderCheck = false;
        }

    }
}