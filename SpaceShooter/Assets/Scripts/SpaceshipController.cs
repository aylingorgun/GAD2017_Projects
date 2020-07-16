using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

    Rigidbody2D rb;
    int speed = 5;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        float vertical = Input.GetAxis("Vertical");    
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal, vertical) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(0);
            bullet.SetActive(true);
            bullet.gameObject.transform.position = this.gameObject.transform.position;
        }
	}
}
