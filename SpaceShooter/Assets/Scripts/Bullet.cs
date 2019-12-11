using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    int speed = 5;

    private void OnEnable()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
