using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    private Transform Enemy;
    // private float distance;

    public HealthBar healthBar;
    public int maxHealth = 200;
    public float currentHealth;
    public int damageAmount = 10;
    public int potioncounter = 0;

    int isWalkingHash;
    int isAttackingHash;

    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        isWalkingHash = Animator.StringToHash("isWalking");
        isAttackingHash = Animator.StringToHash("isAttacking");
        currentHealth = (float) maxHealth;
        healthBar.SetMaxHealth(maxHealth); //first it will be our max amount 
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isAttacking = animator.GetBool(isAttackingHash);
        bool walkPressed =  Input.GetMouseButton(0);
        bool attackPressed = Input.GetMouseButton(1);
        bool potionPressed = Input.GetKeyDown(KeyCode.F);
        
        if (attackPressed)
        {
            agent.ResetPath();

          
            animator.SetBool(isAttackingHash, true);
            transform.LookAt(Enemy); //if they are close so enemy will look at the player
            agent.SetDestination(transform.position);
            //TakeDamage(20);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") 
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8)
        {
            animator.SetBool(isAttackingHash, false);
        }

        if (agent.velocity.magnitude > 1)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (potionPressed)
        {
            healthPotion();
            
        }
        
        // distance = Vector3.Distance(Enemy.position, transform.position);
        // if (distance < 3.5f)
        // {
        //     if (enemy.tag == "Enemy")
        //     {
        //         enemy.GetComponent<enemy>().EnemyTakeDamage(damageAmount);//the func in enemy script
        //     }
        // }
        /*
        //when we pressed mouse left button the isWalking boolean will be set to true
        if (!isWalking && walkPressed)
        {
            animator.SetBool(isWalkingHash , true);
        }
        
        if (isWalking && !walkPressed)
        {
            animator.SetBool(isWalkingHash , false);
        }
        
        //when we pressed left shift the isAttacking boolean will be set to true
        if (!isAttacking && attackPressed)
        {
            animator.SetBool(isAttackingHash , true);
        }
        
        if (isAttacking && !attackPressed)
        {
            animator.SetBool(isAttackingHash , false);
        }
        */
    }

    public void AttackAnimationEvent()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 2, enemyLayer);

        foreach (var col in cols)
        {
            col.GetComponent<enemy>().EnemyTakeDamage(damageAmount); 
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        float sliderValue =(float) currentHealth / maxHealth;
        healthBar.SetHealth(sliderValue); //update it every time it takes damage
        if (currentHealth == 0)
        {
            PlayerManager.isGameOver = true;
            //gameObject.SetActive(false);
        }
    }
    public void healthPotion()
    {
        if(potioncounter < 5) { 
        
        currentHealth = (float) maxHealth;
        healthBar.SetHealth(currentHealth);
        potioncounter++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //TakeDamage(1);
     //   if (other.tag == "Enemy")
       // {
         //   other.GetComponent<enemy>().EnemyTakeDamage(damageAmount);//the func in enemy script
       // }
        
    }
    
}
