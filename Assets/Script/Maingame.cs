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

    //SHOP
    public int shop1prize;
    public Text shop1text;

    public int shop2prize;
    public Text shop2text;

    //AMOUNT
    public Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public Text amount2Text;
    public int amount2;
    public float amount2Profit;

    //Use this for init
    void Start()
    {
        //CLIKER
        currentScore = 0;
        hitPower = 1;
        scoreIncreasePerSecond = 1;
        x = 0f;
    }

    //Update per frame
    void Update()
    {
        //CLIKER
        scoreText.text = "Money : " + (int)currentScore + " $";
        scoreIncreasePerSecond = x * Time.deltaTime;
        currentScore = currentScore + scoreIncreasePerSecond;

        //SHOP
        shop1text.text = "Tier 1: " + shop1prize + " $";
        shop2text.text = "Tier 2: " + shop2prize + " $";

        //AMOUNT
        amount1Text.text = "Tier 1: " + amount1 + " arts $:" + amount1Profit + "/s";
        amount2Text.text = "Tier 2: " + amount2 + " arts $:" + amount2Profit + "/s";
    }

    public void Hit()
    {
        //CLIKER
        currentScore += hitPower;
    }

    public void Shop1()
    {
        if(currentScore>=shop1prize)
        {
            currentScore -= shop1prize;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1prize += 25;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2prize)
        {
            currentScore -= shop2prize;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2prize += 125;
        }
    }
}
