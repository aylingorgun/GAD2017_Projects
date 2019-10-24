using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    public float speed = 2;
    public float force = 300;
    // Start is called before the first frame update
    void Start()
    {
       this.GetComponent<Rigidbody2D>().velocity = Vector2.right* speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
