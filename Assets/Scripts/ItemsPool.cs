using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemsPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ItemsPool Instans;

    private void Awake()
    {
        Instans = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;
    void Start()
    {
        poolDict= new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
               GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDict.Add(pool.tag, objectPool);
        }
        
    }
    public GameObject SpawnFromPool (string tag, Vector2 position, Quaternion rotation)
    {
        if (!poolDict.ContainsKey(tag))
        {
            return null;
        }

       GameObject objToSpawn = poolDict[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        IPoolObjectScript pooledObj = objToSpawn.GetComponent<IPoolObjectScript>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDict[tag].Enqueue(objToSpawn);
        
        return objToSpawn;
    }
}
