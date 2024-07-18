using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTorsion : MonoBehaviour
{

    protected Transform player;
    protected Vector3 mousePos;
    public Vector3 direction;
    public Vector3 playerDirection;
    protected float enemyAxeCount;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos;
        playerDirection = player.transform.position;


    }
    private void FixedUpdate()
    {
        if (direction.x < playerDirection.x)
        {
            gameObject.transform.Rotate(0, 0, 15);

        }
        else if (direction.x > playerDirection.x)
        {
            gameObject.transform.Rotate(0, 0, -15);
        }
        
    }
   
    private void OnTriggerEnter2D(Collider2D over)
    {
        if (over.gameObject.tag == "Enemy")
        {
            enemyAxeCount++;
            if (enemyAxeCount >= 7)
            {
                Destroy(gameObject);
            }
        }
    }

}
