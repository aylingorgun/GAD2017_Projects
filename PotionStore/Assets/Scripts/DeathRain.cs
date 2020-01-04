using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRain : MonoBehaviour
{
    private float InstantiationTimer = 2f;
    public GameObject go;
    public Transform spawn;

    void Update()
    {
        CreatePrefab();
    }

    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(go, spawn.position, spawn.rotation);
            InstantiationTimer = 2f;
        }
    }
}
