using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private AudioSource playerSound;
    public AudioClip itemUp;
    public AudioClip playerHittedSound;
    public AudioClip playerFootStaps;
    public float footStapsTime = 0.33f;

    protected Rigidbody2D playerRb;
    public static float playerLives = 10;
    float moveSpeed = 2;
    Vector2 movement;
    protected Vector2 hitDirection;
    public static float playerScore;
    public Animator animator;
    public bool fasingR = true;
    private float timeAfterHit;
    [SerializeField] protected float punchForce;

    [SerializeField] public bool attackSpeedUp;
    [SerializeField] public float attackSpeedUpTime;
    [SerializeField] protected float attackSpeedUpTimeBase;

    public float axeCount;

    [SerializeField] protected GameObject Beast;
    [SerializeField] protected float beastTime;
    [SerializeField] public float beastCooldown = 15;
    protected bool beastOn;

    public ParticleSystem boom;
    public GameOverScreen gameOver;
    public InfinitGameOverScreen infinitGameOver;
    public GameObject theFinalSpell;

    protected float moveStopForEnemyPunch;

    void Start()
    {
      
        playerLives = 10f;
        playerScore = 0;
        playerSound = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        if (beastTime >= 3)
        beastCooldown+= Time.deltaTime;
       if(Input.GetButtonDown("Jump") && beastCooldown >= 15 && beastTime == 3)
       {
           Beast.gameObject.SetActive(true);
            beastOn = true;
            beastCooldown = 0;
            
       }
       else if (beastOn==true)
        {
            beastTime -= Time.deltaTime;
            if (beastTime <= 0) 
            {
                Beast.gameObject.SetActive(false); 
                beastTime= 3;
                beastOn = false;
            }
            

        }
      
        attackSpeedUpTime -= Time.deltaTime;
        if (attackSpeedUpTime < 0 )
        {
            attackSpeedUp = false;
        }
        if (SceneManager.GetActiveScene().name == "Main")
        {
            theFinalSpell.gameObject.SetActive(playerScore >= 100);
            if (playerScore >= 100 && Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene("WinnerScene");
            }
        }
        timeAfterHit += Time.deltaTime;

        movement = new Vector2( Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        
        animator.SetFloat("run",Mathf.Abs(movement.x));
        
        animator.SetFloat("runUp", Mathf.Abs(movement.y));
        if (movement.x < 0 && fasingR)
        {
            Flip();
        }
        else if(movement.x> 0 && !fasingR)
        {
            Flip();
        }
        footStapsTime -= Time.deltaTime;
        if (movement.x != 0 || movement.y != 0)
        {
            if (footStapsTime < 0)
            {
                playerSound.PlayOneShot(playerFootStaps);
                footStapsTime = 0.33f;
            }
            

        }

        

    }
    private void FixedUpdate()
    {       
        moveStopForEnemyPunch -= Time.deltaTime;
        if (moveStopForEnemyPunch <= 0) 
        { 
          playerRb.MovePosition(playerRb.position+movement*moveSpeed*Time.fixedDeltaTime);
        }
    }
    void Flip()
    {
        fasingR = !fasingR;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
   
    void OnTriggerEnter2D (Collider2D over)
    {
        if (over.gameObject.tag == "Enemy")
        {
            if (timeAfterHit > 0.7058823f)
            {
                moveStopForEnemyPunch = 0.1f;
                Vector2  hitDirection = (transform.position - over.transform.position).normalized;
                playerRb.velocity = hitDirection * punchForce * Time.fixedDeltaTime;                                        
                playerSound.PlayOneShot(playerHittedSound);
                timeAfterHit = 0;
                animator.SetTrigger("PlayerHitted");
                playerLives-=1;

               
            }
            if (playerLives == 0)
            {
                Destroy(gameObject);
                Instantiate(boom, transform.position, transform.rotation);
                if (SceneManager.GetActiveScene().name == "Main")
                    gameOver.GameOverScreenOn();
                if (SceneManager.GetActiveScene().name == "Infinite")
                    infinitGameOver.InfinitGameOverScreenOn();

            }

        }
        if (over.gameObject.tag == "Bullet")
        {
           
            if (timeAfterHit > 0.7058823f)
            {
                playerSound.PlayOneShot(playerHittedSound);
                timeAfterHit = 0;
                animator.SetTrigger("PlayerHitted");
                playerLives--;
            }            
            if (playerLives == 0)
            {
                Destroy(gameObject);
                Instantiate(boom, transform.position, transform.rotation);
                if (SceneManager.GetActiveScene().name == "Main")
                    gameOver.GameOverScreenOn();
                if (SceneManager.GetActiveScene().name == "Infinite")
                    infinitGameOver.InfinitGameOverScreenOn();
            }
        }
        if (over.gameObject.tag == "Item")
        {
            playerSound.PlayOneShot(itemUp, 1f);
            Destroy(over.gameObject);
            playerScore++;
        }
        if (over.gameObject.tag == "AttackSpeedUp")
        {
            playerSound.PlayOneShot(itemUp, 1f);
            Destroy(over.gameObject);
            attackSpeedUpTime = attackSpeedUpTimeBase;
            attackSpeedUp = true;
            
        }
        if (over.gameObject.tag == "AxeBonus")
        {
            playerSound.PlayOneShot(itemUp, 1f);
            Destroy(over.gameObject);
            axeCount++;
        }
        if (over.gameObject.tag == "HpBonus" && playerLives < 10)
        {
            playerSound.PlayOneShot(itemUp, 1f);
            Destroy(over.gameObject);
            playerLives++;
        }
    }
    
 
  
}
