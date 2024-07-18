using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySooting : MonoBehaviour, IPoolObjectScript
{
    public float fireBallSpeed;
    GameObject player;
    private Rigidbody2D rb;
    Vector3 direction;
    float rot;
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * fireBallSpeed;
        rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

    }
}
