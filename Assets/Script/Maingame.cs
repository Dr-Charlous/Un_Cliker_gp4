using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maingame : MonoBehaviour
{
    //CLIKER
    public GameObject Button;
    public Text scoreText;
    public double currentScore;
    public float hitPower;
    public float scoreIncreasePerSecond;
    public float x;

    //SHOP
    public GameObject ShopButton;
    public GameObject MenuButton;
    public GameObject MenuShop;
    public GameObject MenuMenu;
    public GameObject Auto1;
    private int Auto1Save = 0;
    public GameObject Auto2;
    private int Auto2Save = 0;
    public GameObject Pub;
    private int PubSave = 0;

    public double shop1prize;
    public Text shop1text;

    public double shop2prize;
    public Text shop2text;

    //AMOUNT
    public Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public Text amount2Text;
    public int amount2;
    public float amount2Profit;

    //UPGRADE
    public double upgradePrize;
    public Text upgradeText;

    //XXLUP
    public int allUpgradePrize;
    public Text allUpgradeText;

    public List<Sprite> ChenilUp = new List<Sprite>();
    private int lvlChenil = 0;

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
        shop1prize = 75;
        shop2prize = 750;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 10;

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
        lvlChenil = PlayerPrefs.GetInt("lvlChenil", 0);
        Auto1Save = PlayerPrefs.GetInt("Auto1Save", 0);
        Auto2Save = PlayerPrefs.GetInt("Auto2Save", 0);
        PubSave = PlayerPrefs.GetInt("PubSave", 0);
    }



    //Update per frame
    void Update()
    {
        //CLIKER
        scoreText.text = "Money : " + (int)currentScore + " $";
        scoreIncreasePerSecond = x * Time.deltaTime;
        currentScore = currentScore + scoreIncreasePerSecond;

        Image image = Button.GetComponent<Image>();
        image.sprite = ChenilUp[lvlChenil];

        //SHOP
        shop1text.text = "Auto 1: " + (int)shop1prize + " $";
        shop2text.text = "Auto 2: " + (int)shop2prize + " $";

        //AMOUNT
        amount1Text.text = "Auto 1: " + (int)amount1 + " dogs $:" + (int)amount1Profit + "/s";
        amount2Text.text = "Auto 2: " + (int)amount2 + " family $:" + (int)amount2Profit + "/s";

        //UPGRADE
        upgradeText.text = "Cost: " + (int)upgradePrize + " $";

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
        PlayerPrefs.SetInt("lvlChenil", (int)lvlChenil);
        PlayerPrefs.SetInt("Auto1Save", (int)Auto1Save);
        PlayerPrefs.SetInt("Auto2Save", (int)Auto2Save);
        PlayerPrefs.SetInt("PubSave", (int)PubSave);

        //XXLUP
        allUpgradeText.text = "Cost: " + (int)allUpgradePrize + " $";

        //RANDOM GOLD
        if(nowIsEvent == false && goldButton.active == true)
        {
            goldButton.SetActive(false);
            StartCoroutine(WaitForEvent());
        }

        if(nowIsEvent == true && goldButton.active == false)
        {
            goldButton.SetActive(true);
            goldButton.transform.position = new Vector3(Random.Range(-6, 6), Random.Range(-6, 6), 0);
        }

        //HIT
        plusText.text = "+ " + hitPower;

        //Upp
        if(Auto1Save == 1)
        {
            Auto1.SetActive(true);
        }
        if (Auto2Save == 1)
        {
            Auto2.SetActive(true);
        }
        if (PubSave == 1)
        {
            Pub.SetActive(true);
        }
    }



    public void Hit()
    {
        //CLIKER
        currentScore += hitPower;

        //HIT
        plusObject.SetActive(true);

        plusObject.transform.position = new Vector3(Random.Range(0, 6), Random.Range(-4, 2), 0);
        
        //plusObject.SetActive(false);

        StopAllCoroutines();
        StartCoroutine(Fly());
    }



    public void ShopBut()
    {
        MenuShop.SetActive(!MenuShop.activeSelf);
    }
    public void MenuBut()
    {
        MenuMenu.SetActive(!MenuMenu.activeSelf);
    }

    public void Shop1()
    {
        if(currentScore>=shop1prize)
        {
            currentScore -= shop1prize;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1prize *= 1.2f;

            Auto1.SetActive(true);
            Auto1Save = 1;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2prize)
        {
            currentScore -= shop2prize;
            amount2 += 1;
            amount2Profit += 10;
            x += 10;
            shop2prize *= 1.3f;

            Auto2.SetActive(true);
            Auto2Save = 1;
        }
    }



    //UPGRADE
    public void Upgrade()
    {
        if(currentScore >= upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower+=1;
            upgradePrize *= 1.2f;

            Pub.SetActive(true);
            PubSave = 1;
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

            if(lvlChenil < ChenilUp.Count-1)
            {
                lvlChenil++;
            }
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

            plusObject.transform.position = new Vector3(plusObject.transform.position.x, plusObject.transform.position.y + 0.05f, 0);
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

        lvlChenil = 0;

        //SET ALL VAR BEFORE LOAD
        shop1prize = 75;
        shop2prize = 750;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 10;

        allUpgradePrize = 8000;
        upgradePrize = 5;

        //SET UPP
        Pub.SetActive(false);
        PubSave = 0;
        Auto1.SetActive(false);
        Auto1Save = 0;
        Auto2.SetActive(false);
        Auto2Save = 0;
        MenuShop.SetActive(false);
        MenuMenu.SetActive(false);
    }

}
