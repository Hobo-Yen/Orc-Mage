using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMageScript : CommonEnemyScript
{
    [SerializeField] protected GameObject star;
    [SerializeField] protected bool enemyAttacking = false;
    [SerializeField] protected bool enemyBigMageRun;
    [SerializeField] protected GameObject fireball;
    [SerializeField] protected float rageLives;
    [SerializeField] protected float rageTime;
    [SerializeField] protected float rageCooldown;
    
    
    
    protected override void FixedUpdate()
    {
        if (stun == false && enemyAttacking == false && GameObject.FindGameObjectWithTag("Player")&& Vector2.Distance(transform.position, player.position) > stopingDistance)
        {
            enemyBigMageRun = true;
            if (!enemySounds.isPlaying)
                enemySounds.PlayOneShot(stepSound);
            Movement();

        }
        else
        {
            enemyBigMageRun = false;
        }
    }
    protected override void Attack()
    {
        
        rageCooldown -= Time.deltaTime;
                
        if (Vector2.Distance(transform.position, player.position) <= stopingDistance && rageCooldown <=0 && enemyAttacking == false) 
        {
            enemyAttacking = true;
            timeBtwAttack = 0.5f;
            rageLives = 10; rageTime = 0;
        }
        if (timeBtwAttack <= 0 && enemyAttacking == false)
        {
            itemsPool.SpawnFromPool("FireBall", transform.position, Quaternion.identity);
            timeBtwAttack = startTimeBtwAttack;
        }
        else if (enemyAttacking)
        {
            
            rageTime += Time.deltaTime;

            if (timeBtwAttack <= 0 && rageTime < 10)
            {
                for (int i = 0; i < 6; i++)
                {
                    itemsPool.SpawnFromPool("Stars", transform.position, Quaternion.identity);
                }                
                timeBtwAttack = startTimeBtwAttack / 4;
            }
            else if (timeBtwAttack <= 0 && rageTime < 20)
            {

                for (int i = 0; i < 9; i++)
                {
                    itemsPool.SpawnFromPool("Stars", transform.position, Quaternion.identity);
                }
                timeBtwAttack = startTimeBtwAttack / 4;
            }
            else if (timeBtwAttack <= 0 && rageTime > 20)
            {

                for (int i = 0; i < 12; i++)
                {
                    itemsPool.SpawnFromPool("Stars", transform.position, Quaternion.identity);
                }
                timeBtwAttack = startTimeBtwAttack / 4;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }
    protected override void Movement()
    {
        if (Vector2.Distance(transform.position, player.position) > stopingDistance && enemyAttacking == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);            
        }
        else if (Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retritDistance)
        {
            transform.position = this.transform.position;
        }

    }
    protected override void Animations()
    {
        animator.SetBool("enemyBigMageRun", enemyBigMageRun);
        animator.SetBool("enemyBigMageStun", stun);
        animator.SetBool("enemyBigMagAttaking", enemyAttacking);
    }

    protected override void OnTriggerEnter2D(Collider2D over)
    {

        
        if (over.gameObject.tag == "Bullet")
        {
            if (!enemyAttacking)
                animator.SetTrigger("enemyBigMageHitted");
            if (enemyAttacking)
                animator.SetTrigger("enemyBigMageHittedwileAttacking");
            if (enemyAttacking && rageLives > 0) 
            {
                animator.SetTrigger("enemyBigMageHittedwileAttacking");
                rageLives--; 
            }
            else if (enemyAttacking && rageLives <= 0)
            {
                enemyAttacking = false;
                rageCooldown = 15;
            }
        }
        if (over.gameObject.tag == "Axe")
        {
            if (!enemyAttacking)
                animator.SetTrigger("enemyBigMageHitted");
            if (enemyAttacking)
                animator.SetTrigger("enemyBigMageHittedwileAttacking");
            if (enemyAttacking && rageLives > 0)
            {
                animator.SetTrigger("enemyBigMageHittedwileAttacking");
                rageLives -=5;
            }
            else if (enemyAttacking && rageLives <= 0)
            {
                enemyAttacking = false;
                rageCooldown = 15;
            }
        }
        base.OnTriggerEnter2D(over);
    }
    protected override void OnTriggerStay2D(Collider2D over)
    {
        if (over.gameObject.tag == "Beast" && enemyAttacking == false)
        {
            stun = true;
            stunTime = baseStunTime;
        }
       
    }

}
