using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;
    //Lugar del arma de donde saldra la bala

    public GameObject bullet;
    //Modelo en modo de GameObject de la bala

    public float shootForce = 1500f;
    //Velocidad de la bala

    public float shootRate = 0.5f;
    //Velocidad en la que sale una nueva bala
    

    private float shootRateTime = 0;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//Verifica si se presiona el click del mouse si es asi entonces
        {
            if (Time.time > shootRateTime) //el tiempo pasado desde el click es mayor a la cadencia de tiro entonces
            {
                GameObject newBullet;// crea un objeto osea una nueva bala
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);// esa nueva bala con el spawnpoint creado y rotacion que tenga este
                newBullet.GetComponent<Rigidbody>().AddForce(-spawnPoint.up * shootForce);// La nueva bala con un componente de fuerza se desplaza hacia adelante con la velocidad de shootforce
                Rigidbody rb = newBullet.GetComponent<Rigidbody>();
                rb.useGravity = true;
                shootRateTime = shootRate + Time.time;//shootrate time pasa a valer la cadencia de tiro mas el tiempo en el que se disparo
                //este tiempo tiene que ser menor desde el ultimo click para volver a disparar

            }

        }

    }
}
