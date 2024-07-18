using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    private AudioSource enemySounds;
    public AudioClip hitted;
    public AudioClip stepSound;
   

    public ParticleSystem boom;
    public float enemyLives = 3;
    public float enemySpeed;
    public float stopingDistance;
    public float retritDistance;

    private float timeBtwShoot;
    public float startTimeBtwShoot;
    public GameObject fireball;

    private float xRange = 6.25f;
    private float yRange = 6.06f;

    private Transform player;
    Vector3 enemyPos;

    private bool playerR;

    public Animator animator;

    public GameObject bob;
    // Start is called before the first frame update
    void Start()
    {
        enemySounds= GetComponent<AudioSource>();
        
        player = GameObject.FindWithTag("Player").transform;
        
        timeBtwShoot = startTimeBtwShoot;
    }
    

    // Update is called once per frame
    void Update()
    {
        enemyPos = transform.position;
        Range();
        if (enemyPos.x < player.transform.position.x && playerR)
        { EnemyFlip(); }
        if (enemyPos.x > player.transform.position.x && !playerR)
        { EnemyFlip(); }

        if (timeBtwShoot <= 0)
        {
            
            Instantiate(fireball,transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            timeBtwShoot = startTimeBtwShoot;
        }
        else
        {
            timeBtwShoot -= Time.deltaTime;
        }
        animator.SetFloat("enemyRun", Vector2.Distance(transform.position, player.position));
        animator.SetFloat("enemyRunUp", Vector2.Distance(transform.position, player.position));
        if (Vector2.Distance(transform.position, player.position) > 2|| Vector2.Distance(transform.position, player.position)<1)
        {
            if (!enemySounds.isPlaying)
                enemySounds.PlayOneShot(stepSound);
        }

       
    }
    
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) > stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retritDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retritDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -enemySpeed * Time.deltaTime);
        }


    }
    void EnemyFlip()
    {
        playerR = !playerR;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    void Range()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

    }
    void OnTriggerEnter2D(Collider2D over)
    {
        if (over.gameObject.tag =="Bullet")
        {            
            enemyLives--;
            Destroy(over.gameObject);            
            animator.SetTrigger("EnemyHitted ");
            enemySounds.PlayOneShot(hitted,1f);

        }
        if (enemyLives == 0)
        {
            Instantiate(boom,transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(bob,transform.position,transform.rotation);
        }
    }
}

