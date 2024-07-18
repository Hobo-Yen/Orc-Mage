using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public YouWonScript youWonScript;
    public GameObject kaboom;
    public Camera mainCum;
    // Start is called before the first frame update
    void Start()
    { 
        Invoke("Kaboom", 8.0f);
        Invoke("YouWonScreen",12f);
        mainCum= GetComponent<Camera>();
    }
    void YouWonScreen()
    {
        youWonScript.YouWonScreenOn();
    }
    // Update is called once per frame
    void Update()
    {
        if (mainCum.orthographicSize <= 3.5f)
        mainCum.orthographicSize += (Time.deltaTime/2);
       
    }
    void Kaboom()
    {
        Instantiate(kaboom);
    }

}
