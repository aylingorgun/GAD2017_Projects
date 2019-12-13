using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 100f;

    public ParticleSystem MuzzleFlash;
    public ParticleSystem ImpactEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        MuzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            //Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject impactEffect = ObjectPooler.SharedInstance.GetPooledObject(0);
            impactEffect.SetActive(true);
            impactEffect.transform.position = hit.point;
            impactEffect.transform.rotation = Quaternion.LookRotation(hit.normal);
        
        }
    }
}
