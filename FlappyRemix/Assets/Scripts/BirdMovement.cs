using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    public float speed = 2;
    public float force = 300;

    public AudioSource a1;
    public AudioSource a2;
    public AudioSource a3;


    public TextMeshPro textM;
    int score;
    // Start is called before the first frame update
    void Start()
    {
       a2.Stop();
       a3.Stop();

       score = 0;
       textM.text = score.ToString();
       this.GetComponent<Rigidbody2D>().velocity = Vector2.right* speed;
    }

    // Update is called once per frame
    void Update()
    {
        textM.text = score.ToString();

        if (Input.GetMouseButtonDown(0))
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            score += 10;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        else if (collision.gameObject.tag == "sep")
        {
            Destroy(collision.gameObject);
            speed += 2;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            a1.Stop();
            a2.Play();
        }
        else if (collision.gameObject.tag == "sep2")
        {
            Destroy(collision.gameObject);
            speed += 2;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            a2.Stop();
            a2.Play();
        }
        else if (collision.gameObject.tag == "sep3")
        {
            SceneManager.LoadScene(0);
        }
    }



}
