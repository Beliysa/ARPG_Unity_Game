using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]//to make sure that we always have a NavMeshAgent to get
//so unity will automatically add a NavMeshAgent wherever we use this component
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent; //ref to NavMeshAgent
    // Start is called before the first frame update
    void Start()

    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .5f;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget ()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
        
}

