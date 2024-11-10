using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent agent;
    public Transform centrepoint;
    public float range = 3f;
    public bool isFixed = false;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFixed)
        {
            agent.isStopped = false;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 point;
                if (RandomPoint(centrepoint.position, range, out point))
                {
                    agent.SetDestination(point);
                }
            }
        }
        else { agent.isStopped = true; }
        
    }

    bool RandomPoint(Vector3 centr,float range, out Vector3 result)
    {

        Vector3 randomPoint = centr + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) {

            result = hit.position;
            return true;
        };



        result = Vector3.zero;
            return false;
    }
}
