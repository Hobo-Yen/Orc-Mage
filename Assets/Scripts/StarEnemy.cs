using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarEnemy : MonoBehaviour, IPoolObjectScript
{
    public float StarSpeed;
    GameObject player;
    private Rigidbody2D rb;
    Vector3 direction;
    float rot;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = Random.insideUnitCircle;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * StarSpeed;
        rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

    }




    

}
