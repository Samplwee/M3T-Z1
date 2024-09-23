using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    //Prefab de la bala de los enemigos

    public Transform spawnBulletPoint;
    //lugar donde aparecera la bala del enemigo

    private Transform playerPosition;
    //variable de la ubicacion del jugador

    public float bulletVelocity = 100f;
    void Start()
    {
        playerPosition = FindObjectOfType<Playermovement>().transform;
        //Encontramos la posicion del jugador
        Invoke("ShootPlayer", 3);
        Debug.Log("Nueva bala");
    }

    void Update()
    {
        
    }
    void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position - transform.position;
        //direccion a la que debe ir la bala

        GameObject newBullet;

        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
        //Instanciamos la bala enemiga en una posicion y rotacion determinadas

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection*bulletVelocity, ForceMode.Force);
        //Un atributo para la nueva bala esta tendra una fuerza x en direccion al player

        Invoke("ShootPlayer", 3);
        
    }
}
