using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider slider;
    
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = 10;
        slider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerControl.playerLives;
    }
}
