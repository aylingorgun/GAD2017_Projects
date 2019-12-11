using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;

    //public int numberOfPlatforms = 200;
    public float levelWidth = 1.5f;
    public float minY = .5f;
    public float maxY = 1f;

    Vector3 spawnPosition;

    // Use this for initialization
    private void Start()
    {
        spawnPosition = new Vector3();
        //int i = 0; i < numberOfPlatforms; i++

    }

    void Update()
    {

        while (Platform.colliderCheck == true)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            Platform.colliderCheck = false;
        }

    }
}