using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyDoggyScript : CommonEnemyScript
{
    protected float timeAferPunch;
    protected bool enemyBeastRun;


    protected override void FixedUpdate()
    {
       
        timeAferPunch -= Time.deltaTime;
        if (timeAferPunch <= 0 && stun == false && GameObject.FindGameObjectWithTag("Player")) 
        {
            if (!enemySounds.isPlaying)
                enemySounds.PlayOneShot(stepSound);
            enemyBeastRun = true;
            Movement(); 

        }
        else
        {
            enemyBeastRun = false;
        }
        
        
    }

    protected override void Animations()
    {
        if (stun == false)
        {
            animator.SetBool("beastRun",enemyBeastRun);
        }

    }
    protected override void OnTriggerEnter2D(Collider2D over)
    {      
        if (over.gameObject.tag == "Player")
        {
            timeAferPunch = 0.5f;
        }
        if (over.gameObject.tag == "Bullet")
        {
            enemyLives--;
            Destroy(over.gameObject);
            animator.SetTrigger("enemyBeastHitted");
            enemySounds.PlayOneShot(hitted, 1f);
            if (enemyLives <= 0)
            {
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
                Instantiate(ItemDrop(), transform.position, transform.rotation);
            }

        }
        if (over.gameObject.tag == "Axe")
        {
            enemyLives -= 5;
            //animator.SetTrigger("");            
            if (enemyLives <= 0)
            {
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
                Instantiate(ItemDrop(), transform.position, transform.rotation);
            }
        }      
    }
    protected override void OnTriggerStay2D(Collider2D over)
    {
        if (over.gameObject.tag == "Beast")
        {
            stun = true;
            stunTime = baseStunTime;            
        }
        animator.SetBool("enemyBeastStun", stun);
    }
}
