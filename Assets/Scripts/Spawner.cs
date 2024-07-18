using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] protected GameObject[] enemys;
    [SerializeField] protected float spawnTimeBase;
    [SerializeField] protected float spawnTime;
    [SerializeField] protected float enemyCount;
    [SerializeField] protected float enemysSum;
    [SerializeField] protected int numberOfEnemy;
    [SerializeField] protected float baseTime;
    public GameObject bigMagIsActive;

    void Start()
    {
        baseTime = 0;      
    }
    void Update()
    {
        Debug.Log(baseTime+=Time.deltaTime);
        enemysSum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        bigMagIsActive = GameObject.Find("BIgMage(Clone)");

        if (baseTime >= 30 && baseTime <= 120)
        {
            spawnTime = 2.5f;
        }
        else if (baseTime >= 120 && baseTime <= 180)
        {
            spawnTime = 2f;
        }
        else if (baseTime >= 180 && baseTime <= 300)
        {
            spawnTime = 1.5f;
        }
        else if (baseTime >= 360)
        {
            spawnTime = 1f;
        }

        if (spawnTimeBase <= 0 && enemysSum < 40)
        {
            Spawn();
            spawnTimeBase = spawnTime;
        }
        else
        {
            spawnTimeBase -= Time.deltaTime;
        }
       
       
    }
    void Spawn () 
    {
        if (enemyCount < 30)
        {
            numberOfEnemy = Random.Range(0, 2);
            enemyCount++;
        }
        else if (enemyCount >= 30 && bigMagIsActive)
        {
            numberOfEnemy = Random.Range(0, 2);
            enemyCount++;
        }
        else if (enemyCount >= 30 && !bigMagIsActive)
        {
            numberOfEnemy = 2;
            enemyCount = 0;
        }

        Vector2 spounPosHorizontalUp = new (Random.Range(-10, 10), 10);
        Vector2 spounPosHorizontalDown = new (Random.Range(-10, 10), -10);
        Vector2 spounPosVerticalR = new (10, Random.Range(-10, 10));
        Vector2 spounPosVerticalL = new (-10, Random.Range(-10, 10));               

        if (transform.position.x>=0 && transform.position.y >= 0)
        {
            Vector2[] spawnPos = new Vector2[] { spounPosHorizontalDown, spounPosVerticalL };
            Instantiate(enemys[numberOfEnemy], spawnPos[Random.Range(0, 2)], transform.rotation);
        }
        else if (transform.position.x <= 0 && transform.position.y >= 0)
        {
            Vector2[] spawnPos = new Vector2[] {spounPosHorizontalDown, spounPosVerticalR,};
            Instantiate(enemys[numberOfEnemy], spawnPos[Random.Range(0, 2)], transform.rotation);
        }
        else if (transform.position.x <= 0 && transform.position.y <= 0)
        {
            Vector2[] spawnPos = new Vector2[] { spounPosHorizontalUp, spounPosVerticalR,};
            Instantiate(enemys[numberOfEnemy], spawnPos[Random.Range(0, 2)], transform.rotation);
        }
        else if (transform.position.x >= 0 && transform.position.y <= 0)
        {
            Vector2[] spawnPos = new Vector2[] { spounPosHorizontalUp, spounPosVerticalL };
            Instantiate(enemys[numberOfEnemy], spawnPos[Random.Range(0, 2)], transform.rotation);
        }
       

    }
    
}
