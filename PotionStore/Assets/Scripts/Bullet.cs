using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {

    int speed = 20;
    public Rigidbody2D rb;

    /*
    private void OnEnable()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
    }

    void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }*/

    private void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if (collision.collider.tag == "Enemy")
        {
            Destroy(this.gameObject);

        }

        if (collision.collider.tag == "Enemy2")
        {
            Enemy.phantom -= 10;
            Destroy(this.gameObject);
            if (Enemy.phantom <= 0)
            {
                Destroy(collision.gameObject);
                Enemy.phantom = 100;
            }

        }
    }
}
