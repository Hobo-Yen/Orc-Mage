using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : CommonEnemyScript
{
    [SerializeField] protected GameObject fireball;
    protected override void Attack()
    {
        if (timeBtwAttack <= 0 && Vector2.Distance(transform.position, player.position) < 5)
        {

            itemsPool.SpawnFromPool("FireBall", transform.position, Quaternion.identity);

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
 
    }
    protected override void Animations()
    {
        if (stun == false)
        {
            animator.SetFloat("enemyRun", Vector2.Distance(transform.position, player.position));
            animator.SetFloat("enemyRunUp", Vector2.Distance(transform.position, player.position));
        }

        if (Vector2.Distance(transform.position, player.position) > 2 || Vector2.Distance(transform.position, player.position) < 1)
        {
            if (!enemySounds.isPlaying)
                enemySounds.PlayOneShot(stepSound);
        }
    }
    protected override void OnTriggerEnter2D(Collider2D over)
    {
        if (over.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("EnemyHitted");
        }
            base.OnTriggerEnter2D(over);
    }
    protected override void OnTriggerStay2D(Collider2D over)
    {
        if (over.gameObject.tag == "Beast")
        {
            stun = true;
            stunTime = baseStunTime;
        }
        animator.SetBool("enemyWizardStun", stun);
    }

}
