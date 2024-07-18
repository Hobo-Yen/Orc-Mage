using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BobCouterScript : MonoBehaviour
{
    public TextMeshProUGUI bobCounts;

    void Start()
    {
        bobCounts.text = "0";
    }


    void Update()
    {

        bobCounts.text = "" + PlayerControl.playerScore;
    }
}
