using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider= gameObject.GetComponent<Slider>();
        slider.minValue= 0;
        slider.maxValue= 100;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value= PlayerControl.playerScore;

    }
}
