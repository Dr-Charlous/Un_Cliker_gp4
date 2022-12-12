using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject ButtonStart;
    public GameObject ButtonCredit;
    public GameObject ButtonQuit;

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Maingame");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickCredit()
    {
        SceneManager.LoadScene("Credit");
    }
}
