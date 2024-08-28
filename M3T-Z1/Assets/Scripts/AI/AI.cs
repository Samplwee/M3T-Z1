using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
 
    public NavMeshAgent navMeshAgent;
    //Llama a la malla de navegacion para saber cual es
 
    public Transform[] destinations;
    //puntos a cuales ir

    private int i = 0;
    //Dentro de un array de posiciones, empezamos moviendonos a la posicion 0 luego i aumenta y cambia de punto al cual ir

    private GameObject player;
    //Definir al jugador

    public bool followPlayer;
    //Seguir al jugador si o no

    private float distanceToPlayer;
    //Variable para almacenar la distacia con nuesto jugador

    public float distanceToFollowPlayer = 10;

    public float distanceToFollowPath = 2;

    void Start()
    {
        navMeshAgent.destination = destinations[i].transform.position;
        player = FindObjectOfType<Playermovement>().gameObject;
        //El jugador va a ser todo lo que tenga el script de PlayerMovement
    }


    void Update()
    {
       distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //distancia del jugador igual a la poscion del enemigo y la del player

        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
            //Si la distancia entre el jugador y el enemigo es menor a la distancia maxima a la que se puede ver el jugador se llama a la funcion follow player
        }
        else
        {
            EnemyPath();
        }

    }

    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)//Verifica la distancia entre el enemigo y el siguiente punto al que tiene que ir
        {
            if (destinations[i] != destinations[destinations.Length - 1])//Verifica que la cantidad de puntos no sea excedida
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
        //Le dice al enemigo que en dentro de la malla de navegacion su siguiente destino sera la posicion del player
    }
}
