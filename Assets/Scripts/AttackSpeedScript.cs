using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSpeedScript : MonoBehaviour
{

    Slider slider;
    GameObject player;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = 5;
        slider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        slider.value = playerControl.attackSpeedUpTime;
    }
}
