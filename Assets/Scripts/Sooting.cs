using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Sooting : MonoBehaviour
{
    public GameObject fireball;
    public Transform firePoint;    
    public float fireballSpeed = 70;
    GameObject player;
    [SerializeField] protected PlayerControl playerControl;
    [SerializeField] protected bool attackSpeedUp;
    [SerializeField] protected GameObject axe;    
    private float rateOfFire;
    GameObject axeClone;
   

    Vector2 lookDirection;
    float lookAngle;
    Vector2 mousePos;
    void Start()
    {
        

    }
    void Update()
    {
       
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        attackSpeedUp = playerControl.attackSpeedUp;        
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = new Vector2(lookDirection.x - transform.position.x, lookDirection.y - transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0,0,lookAngle);
        rateOfFire-= Time.deltaTime;
        if (Input.GetMouseButton(0) && rateOfFire<0 && attackSpeedUp == false)            
        {
            rateOfFire = 0.35f;
            OneShoot();
        }        
        else if (Input.GetMouseButton(0) && rateOfFire < 0 && attackSpeedUp == true)
        {
            rateOfFire = 0.2f;
            OneShoot();
            
        }
        if (Input.GetMouseButtonDown(1) && playerControl.axeCount > 0)
        {
            AxeAttack();
            playerControl.axeCount--;
        }
       
    }
    protected void OneShoot()
    {
        if (mousePos.x < player.transform.position.x)
        {
            GameObject fireballClone = Instantiate(fireball);
            fireballClone.transform.localScale = new Vector3(1, -1, 1);
            fireballClone.transform.position = firePoint.position;
            fireballClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            fireballClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * fireballSpeed;

        }
        else if (mousePos.x > player.transform.position.x)
        {
            GameObject fireballClone = Instantiate(fireball);
            fireballClone.transform.position = firePoint.position;
            fireballClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            fireballClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * fireballSpeed;

        }

    }
    protected void AxeAttack()
    {
       
      
            axeClone = Instantiate(axe);
            axeClone.transform.position = firePoint.position;
            axeClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            axeClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * fireballSpeed*1.5f;
            
        
      
    }



}
