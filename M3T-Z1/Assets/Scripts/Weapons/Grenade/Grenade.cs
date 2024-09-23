using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay =3;
    float countdown; 

    public float radius=7;

    public float explosionforce=70;

    bool exploded=false;

    public GameObject explosionEffect;

    private AudioSource audioSource;

    public AudioClip explosionSound;
 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        countdown = delay;
    }


    void Update()
    {
        countdown-= Time.deltaTime;
        if (countdown <=0 && exploded==false)
        {
            Explode();
            exploded = true;
        }

    }

    void Explode()
    {
        Instantiate(explosionEffect,transform.position,transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(var rangeObjects in colliders)
        {
            Rigidbody rb =rangeObjects.GetComponent<Rigidbody>();

            if(rb!=null)
            {
                rb.AddExplosionForce(explosionforce *10, transform.position,radius);
            }
        }

        audioSource.PlayOneShot(explosionSound);

        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;


        Destroy(gameObject, delay * 2);

    }
}
