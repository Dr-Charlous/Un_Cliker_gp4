using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maingame : MonoBehaviour
{
    //CLIKER
    public Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasePerSecond;
    public float x;

    //Use this for init
    void Start()
    {
        currentScore = 0;
        hitPower = 1;
        scoreIncreasePerSecond = 1;
        x = 0f;
    }

    //Update per frame
    void Update()
    {
        scoreText.text = (int)currentScore + "$";
        scoreIncreasePerSecond = x * Time.deltaTime;
        currentScore = currentScore + scoreIncreasePerSecond;
    }

    public void Hit()
    {
        currentScore += hitPower;
    }
}
