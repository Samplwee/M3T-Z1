using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Archivo GameManager Conoce todo sobre el jugador y su entorno

public class GameManager : MonoBehaviour
{
    public Text ammoText;
    //Toma la municion y se la pasa a la UI

    public Text healthText;
    //Toma la vida y se la pasa a la UI

    public static GameManager Instance { get; private set; }

    public int gunAmmo = 10;
    public int health = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //Convierte la variable que almacena las balas y la vida en string, se alamcena en la variable ammoText/healthText y luego se le pasa esa informacion a la UI
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();
    }

    public void LoseHealth(int healthtoreduce)
    {
        health -= healthtoreduce;
        CheckHealth();
    }
    public void CheckHealth()
    {
        if (health <=0)
        {
            Debug.Log("HAS MUERTO PIBE");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
             
        }
    }

}
