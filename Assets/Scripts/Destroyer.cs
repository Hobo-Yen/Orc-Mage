using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    void Start()
    {       
        Physics2D.IgnoreLayerCollision(3,7);
        Physics2D.IgnoreLayerCollision(6,8);
        Physics2D.IgnoreLayerCollision(7,8);
        Physics2D.IgnoreLayerCollision(8,8);

    }
 
    void Update()
    {       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Walls")
        {
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Walls")
        {
            gameObject.SetActive(false);
        }

    }

}
