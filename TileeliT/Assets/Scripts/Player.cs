using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float movementSpeed = 10f;
    Rigidbody2D rb;
    float movement = 0f;

    public Transform start;
    Vector3 st;
    public Text distance;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        st = start.position;

        distance.GetComponent<Text>().text = "Distance: 0";
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        int dist = (int)Vector3.Distance(st, transform.position);
        distance.text = "Distance: " + dist;
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Respawn")
        {
            GameObject duplicate = Instantiate(GameObject.FindGameObjectWithTag("Player"));
        }   
    }*/
}