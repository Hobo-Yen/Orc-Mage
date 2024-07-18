using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AxeCounterSkript : MonoBehaviour
{
    protected GameObject player;
    public TextMeshProUGUI axeCounts;
    protected float axeCountInCounterSkript;
    // Start is called before the first frame update
    void Start()
    {
        axeCounts.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerControl playerControl = player.GetComponent<PlayerControl>();
        axeCountInCounterSkript = playerControl.axeCount;

        axeCounts.text = "" + axeCountInCounterSkript; 
    }
}
