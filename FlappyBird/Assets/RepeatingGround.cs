using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        float size = this.gameObject.GetComponent<BoxCollider2D>().size.x;
        new Vector2(this.gameObject.GetComponent<BoxCollider2D>().size.x * 2, 0);
        transform.position = (Vector2)this.transform.position + new Vector2(this.gameObject.GetComponent<BoxCollider2D>().size.x * 2, 0);


    }
}
