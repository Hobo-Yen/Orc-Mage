using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossumСooldown : MonoBehaviour
{
    Slider slider;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = 15;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerControl playerControl = player.GetComponent<PlayerControl>();

        slider.value = playerControl.beastCooldown;

    }
}
