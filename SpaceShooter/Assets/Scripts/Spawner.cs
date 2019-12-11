using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject RockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRock", 0, 2);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRock()
    {
        float x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x / 2;
        float x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x / 2;
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(RockPrefab, spawnPoint, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
