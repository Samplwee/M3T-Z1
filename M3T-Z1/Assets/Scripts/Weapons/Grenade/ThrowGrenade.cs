using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float throwforce =500;
    
    public GameObject grenadePrefab;
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G)) 

        {
            Throw();
        }
    }


    public void Throw()
    {

        GameObject newGrenade = Instantiate(grenadePrefab,transform.position,transform.rotation);
        
        newGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * throwforce);

    }
}
