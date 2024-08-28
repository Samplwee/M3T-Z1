using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo; 
            //Al jugador se le van a heredad los componentes del archivo GameManager este dice que las cajas de municion contienen 10 Balas entonces esa sera la cantidad añadida

            Destroy(other.gameObject);
        }
    }
}
