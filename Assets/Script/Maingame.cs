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
    public GameObject ShopButton;
    public GameObject MenuShop;

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

    //UPGRADE
    public int upgradePrize;
    public Text upgradeText;

    //XXLUP
    public int allUpgradePrize;
    public Text allUpgradeText;

    //RANDOM GOLD
    public bool nowIsEvent;
    public GameObject goldButton;

    //RESET
    public GameObject resetButton;

    //HIT
    public GameObject plusObject;
    public Text plusText;






    //Use this for init
    void Start()
    {
        //CLIKER
        currentScore = 0;
        hitPower = 1;
        scoreIncreasePerSecond = 1;
        x = 0f;

        //SET ALL VAR BEFORE LOAD
        shop1prize = 25;
        shop2prize = 125;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 5;

        //RESET LINE
        //PlayerPrefs.DeleteAll();

        //LOAD
        currentScore = PlayerPrefs.GetInt("currentScore", 0);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        x = PlayerPrefs.GetInt("x", 0);

        shop1prize = PlayerPrefs.GetInt("shop1prize", 25);
        shop2prize = PlayerPrefs.GetInt("shop2prize", 125);
        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetInt("amount1Profit", 0);
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetInt("amount2Profit", 0);
        upgradePrize = PlayerPrefs.GetInt("upgradePrize", 50);
        allUpgradePrize = PlayerPrefs.GetInt("allUpgradePrize", 500);
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

        //UPGRADE
        upgradeText.text = "Cost: " + upgradePrize + " $";

        //SAVE
        PlayerPrefs.SetInt("currentScore", (int)currentScore);
        PlayerPrefs.SetInt("hitPower", (int)hitPower);
        PlayerPrefs.SetInt("x", (int)x);

        PlayerPrefs.SetInt("shop1prize", (int)shop1prize);
        PlayerPrefs.SetInt("shop2prize", (int)shop2prize);
        PlayerPrefs.SetInt("amount1", (int)amount1);
        PlayerPrefs.SetInt("amount1Profit", (int)amount1Profit);
        PlayerPrefs.SetInt("amount2", (int)amount2);
        PlayerPrefs.SetInt("amount2Profit", (int)amount2Profit);
        PlayerPrefs.SetInt("upgradePrize", (int)upgradePrize);
        PlayerPrefs.SetInt("allUpgradePrize", (int)allUpgradePrize);

        //XXLUP
        allUpgradeText.text = "Cost: " + allUpgradePrize + " $";

        //RANDOM GOLD
        if(nowIsEvent == false && goldButton.active == true)
        {
            goldButton.SetActive(false);
            StartCoroutine(WaitForEvent());
        }

        if(nowIsEvent == true && goldButton.active == false)
        {
            goldButton.SetActive(true);
            goldButton.transform.position = new Vector3(Random.Range(400, 1500), Random.Range(200, 840), 0);
        }

        //HIT
        plusText.text = "+ " + hitPower;
    }



    public void Hit()
    {
        //CLIKER
        currentScore += hitPower;

        //HIT
        plusObject.SetActive(true);

        plusObject.transform.position = new Vector3(Random.Range(465, 645 + 1), Random.Range(205, 405 + 1), 0);
        
        //plusObject.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(Fly());
    }



    public void ShopBut()
    {
        MenuShop.SetActive(!MenuShop.activeSelf);
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



    //UPGRADE
    public void Upgrade()
    {
        if(currentScore >= upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 3;
        }
    }

    //XXLUP
    public void AllProfitUpgrade()
    {
        if(currentScore >= allUpgradePrize)
        {
            currentScore -= allUpgradePrize;
            x *= 2;
            allUpgradePrize *= 3;
            amount1Profit *= 2;
            amount2Profit *= 2;
        }
    }

    //RANDOM GOLD
    public void GetReward()
    {
        currentScore = currentScore + Random.Range(100, 500);
        nowIsEvent = false;
        StartCoroutine(WaitForEvent());
    }

    //RANDOM EVENT
    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(5f);

        int x = 0;
        x = Random.Range(1, 3);

        if(x == 2)
        {
            nowIsEvent = true;
        } else
        {
            goldButton.SetActive(true);
        }
    }

    //HIT
    IEnumerator Fly()
    {
        for(int i=0;i<=19;i++)
        {
            yield return new WaitForSeconds(0.01f);

            plusObject.transform.position = new Vector3(plusObject.transform.position.x, plusObject.transform.position.y + 2, 0);
        }

        plusObject.SetActive(false);
    }

    //RESET
    public void ResetButton()
    {
        //CLIKER
        currentScore = 0;
        hitPower = 1;
        scoreIncreasePerSecond = 1;
        x = 0f;

        //SET ALL VAR BEFORE LOAD
        shop1prize = 25;
        shop2prize = 125;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 5;

        allUpgradePrize = 500;
        upgradePrize = 500;
    }

}
