using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public GameObject go;
    public GameObject PlayerGameObject;

    public float movementSpeed = 10f;
    Rigidbody2D rb;
    float movement = 0f;

    public Transform start;
    Vector3 st;
    public TextMeshProUGUI distance;
    public TextMeshProUGUI best;

    public Animator anim;
    public AudioSource jump;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        st = start.position;
        go.SetActive(false);

        distance.GetComponent<TextMeshProUGUI>().text = "Distance: 0";

        best.text = "Best: " + PlayerPrefs.GetInt("PersonalBest").ToString();

        jump = GetComponent<AudioSource>();
    }

    void OnBecameInvisible()
    {
        go.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        int dist = (int)Vector3.Distance(st, transform.position);
        distance.text = "Distance: " + dist;

        #region anim
        if (Platform.colliderCheck == true)
        {
            anim.SetBool("isJumping", true);
            jump.Play();
        }
            
        else
            anim.SetBool("isJumping", false);


        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        #endregion

        if (dist >= PlayerPrefs.GetInt("PersonalBest", dist))
        {
            PlayerPrefs.SetInt("PersonalBest", dist);

            best.text = "Best: " + PlayerPrefs.GetInt("PersonalBest", dist).ToString();
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Respawn")
        {
            GameObject duplicate = Instantiate(GameObject.FindGameObjectWithTag("Player"));
        }*/
    }
}