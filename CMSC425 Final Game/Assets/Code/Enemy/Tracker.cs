using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tracker : MonoBehaviour
{
    Transform target;
    //public Transform target;
    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {

        target = GameObject.Find("Player").transform;
        if (!target)
        {
            Debug.Log("DIDNT GET PLAYER");
        }

        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
    }
}
