using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyScript : MonoBehaviour
{
    protected AudioSource enemySounds;
    [SerializeField] protected AudioClip hitted;
    [SerializeField] protected AudioClip stepSound;


    [SerializeField] protected ParticleSystem boom;
    [SerializeField] protected float enemyLives;

    [SerializeField] protected float enemySpeed;
    [SerializeField] protected float stopingDistance;
    [SerializeField] protected float retritDistance;

    [SerializeField] protected float timeBtwAttack;
    [SerializeField] protected float startTimeBtwAttack;

    [SerializeField] protected Rigidbody2D enemyRB;
    protected Transform player;
    Vector3 enemyPos;

    protected bool playerR;

    public bool stun;
    protected float stunTime;
    [SerializeField] protected float baseStunTime;

    [SerializeField] protected Animator animator;

    [SerializeField] protected GameObject bob;
    [SerializeField] protected GameObject [] bonuses;

    protected ItemsPool itemsPool;
    // Start is called before the first frame update
    protected void Start()
    {
        enemySounds = GetComponent<AudioSource>();
        
        player = GameObject.FindWithTag("Player").transform;
            
        timeBtwAttack = startTimeBtwAttack;

        itemsPool = ItemsPool.Instans;
    }


    // Update is called once per frame
    void Update()
    {
        stunTime -= Time.deltaTime;
        if (stunTime <= 0)
        {
            stun = false;
        }
       
        if (stun == false && GameObject.FindGameObjectWithTag("Player"))
        {
            Attack();

            enemyPos = transform.position;
            if (enemyPos.x < player.transform.position.x && playerR)
            { EnemyFlip(); }
            if (enemyPos.x > player.transform.position.x && !playerR)
            { EnemyFlip(); }
        }
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Animations();
        }
        



    }
    protected virtual void Animations()
    {
        
    }
    protected virtual void Attack()
    {
       
    }

    protected virtual void FixedUpdate()
    {
        if (stun == false && GameObject.FindGameObjectWithTag("Player"))
        {
            Movement(); 
        }
    }
    protected virtual void Movement()
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
    
    protected virtual void OnTriggerEnter2D(Collider2D over)
    {
        if (over.gameObject.tag == "Bullet")
        {
            enemyLives--;
            Destroy(over.gameObject);
            enemySounds.PlayOneShot(hitted, 1f);
            if (enemyLives == 0)
            {
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
                Instantiate(ItemDrop(), transform.position, transform.rotation);
            }

        }
        if (over.gameObject.tag == "Axe")
        {
            enemyLives -= 5;   
            if (enemyLives <= 0)
            {
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
                Instantiate(ItemDrop(), transform.position, transform.rotation);
            }
        }
       
    }
    protected virtual void OnTriggerStay2D (Collider2D over)
    {
        if (over.gameObject.tag == "Beast")
        {
            stun = true;
            stunTime = baseStunTime;
        }
    }
    
    protected GameObject ItemDrop()
    {
        int rage = Random.Range(0,4);
        if (rage == 0)
        {
            return bonuses[Random.Range(0, bonuses.Length)];
        }
        else
        {
            return bob;
           
        }
    }
}
