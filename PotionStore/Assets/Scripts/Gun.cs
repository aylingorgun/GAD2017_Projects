using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        } 
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        /*
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(0);
        bullet.SetActive(true);
        bullet.gameObject.transform.position = firePoint.position;
        */
    }
}
