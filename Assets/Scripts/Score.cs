using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoretext;

    private void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = "0";
    }
    void Update()
    {
        scoretext.text = GameObject.Find("game boy").GetComponent<PlayerControls>().score.ToString();
    }
}
