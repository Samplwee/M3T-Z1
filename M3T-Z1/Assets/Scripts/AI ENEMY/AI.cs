using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
 
    public NavMeshAgent navMeshAgent;
    
    public GameObject destination1;

    

    void Start()
    {
        navMeshAgent.destination =destination1.transform.position;
        
    }
    // Update is called once per frame
    void Update()
    {

    }

}
