using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour
{
    
    private Transform player; //reference to the player's position
    private float distance; //distance
    //public float moveSpeed;//enemy's movement speed
    float howClose = 5;//how close we are to the player
    NavMeshAgent agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector3.Distance(player.position, animator.transform.position); //how close the enemy and the player are

        if (distance <= howClose && agent.velocity.magnitude > 1)
        {
            //transform.LookAt(player); //if they are close so enemy will look at the player
            animator.SetBool("isChasing", true);
            //etComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);  //go ahead and move towards the player
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
