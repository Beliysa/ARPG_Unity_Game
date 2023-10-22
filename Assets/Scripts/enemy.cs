using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    private Transform player; //reference to the player's position
    private float distance; //distance
    //public float moveSpeed;//enemy's movement speed
    public float chaseClose = 8;//how close we are to the player
    public float attackClose = 3.5f;//how close we are to the player
    public int HP = 200;
    public Slider HealthBar;

    int isChasingHash;
    int isAttackingHash;

    private int maxValue;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        isChasingHash = Animator.StringToHash("isChasing");
        isAttackingHash = Animator.StringToHash("isAttacking");
        maxValue = HP;

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value =(float) HP / maxValue;
        //bool isChasing = animator.GetBool(isChasingHash);
        distance = Vector3.Distance(player.position, transform.position); //how close the enemy and the player are

        if (distance < chaseClose)
            {
                    animator.SetBool(isChasingHash, true);
                    //transform.LookAt(player); //if they are close so enemy will look at the player
                    agent.SetDestination(player.position); //move our enemy towards the player
                    //etComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);  //go ahead and move towards the player
            }
        else
        {
            animator.SetBool(isChasingHash, false);
        }
        
        //for melee attack or explosive
        if (distance < attackClose)
        {
            //do damage or explode
            transform.LookAt(player); //if they are close so enemy will look at the player
            animator.SetBool(isAttackingHash, true);
            agent.SetDestination(transform.position);
        }
        else
        {
            animator.SetBool(isAttackingHash, false);
        }
        
    }

    
    public void EnemyTakeDamage(int damageAmount)
    {
        Debug.Log("hit");
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
             Destroy(transform.GetComponent<Rigidbody>());
             Destroy(gameObject,1);
            //gameObject.SetActive(false);
            PlayerManager.enemyCount--;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log("player");
    //     Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
    //     //this will be called whenever the player hits an object
    //     foreach (Collider nearByObject in colliders)
    //     {
    //         if (nearByObject.tag == "Player")
    //         {
    //             nearByObject.GetComponent<AnimationStateController>().TakeDamage(1);
    //         }
    //     }
    //     
    // }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("player");
        if (other.tag == "Player")
        {
            other.GetComponent<AnimationStateController>().TakeDamage(10);//the func in enemy script
        }
    }
}
     
    
     