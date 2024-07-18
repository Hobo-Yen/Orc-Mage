using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballDestroyer : MonoBehaviour
{

    void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 7);
        Physics2D.IgnoreLayerCollision(6, 8);
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(8, 8);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
  
}
