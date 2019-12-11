using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    int speed = -5;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            Destroy(gameObject);
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(0);
    }
}
