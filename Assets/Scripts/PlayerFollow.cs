using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    GameObject player;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3(this.player.transform.position.x, this.player.transform.position.y, this.player.transform.position.z-10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target = new Vector3(this.player.transform.position.x+0.32f, this.player.transform.position.y+0.32f, this.player.transform.position.z - 10);
        Vector3 pos = Vector3.Lerp(this.transform.position, target, cameraSpeed * Time.deltaTime);
        this.transform.position = pos;
    }
}
