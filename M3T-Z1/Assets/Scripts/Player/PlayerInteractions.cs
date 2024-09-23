using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public Transform starposition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            //Al jugador se le van a heredad los componentes del archivo GameManager este dice que las cajas de municion contienen 10 Balas entonces esa sera la cantidad añadida

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Deathfloor"))
        {
            Debug.Log("Colision");
            GameManager.Instance.LoseHealth(100);
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = starposition.position;
            GetComponent<CharacterController>().enabled = true;
        }

        if (other.gameObject.CompareTag("Train"))
        {
            Debug.Log("Colision");
            GameManager.Instance.LoseHealth(100);

            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = starposition.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.LoseHealth(5);
        }
    }

}
