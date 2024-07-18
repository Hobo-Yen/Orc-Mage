using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BeastScript : MonoBehaviour
{

    [SerializeField] protected Transform playerTransform;
    protected GameObject player;
    protected bool fasingRInBeast;

    private void Start()
    {
        
        

    }
    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        fasingRInBeast = playerControl.fasingR;
        if (fasingRInBeast == true)
       gameObject.transform.position = playerTransform.position+new Vector3 (0.2294f, -0.05f,0);
        else
            gameObject.transform.position = playerTransform.position + new Vector3(-0.2294f, -0.05f, 0);
    }



}
