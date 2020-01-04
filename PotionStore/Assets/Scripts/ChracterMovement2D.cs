using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChracterMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    private Animator anim;

    public GameObject door;
    public static float health;
    public static float maxhealth = 100;

    public Image healthBar;
    private Vector3 _origPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        door.SetActive(false);

        healthBar = GetComponent<Image>();
        health = maxhealth;
    }

    private void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && isGrounded == true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(0);
            Debug.Log(health);
        }          

        healthBar.fillAmount = health / maxhealth;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }

        if (collision.collider.tag == "Cup")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }

        if (collision.collider.tag == "Key")
        {
            Destroy(collision.gameObject);
            door.SetActive(true);
        }

        if (collision.collider.tag == "Enemy2")
        {
            health -= 20;
        }

        if (collision.collider.tag == "Key2")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(3);
        }
    }

}