using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoGen : MonoBehaviour
{
    //DOGS
    public List<GameObject> myDogList = new List<GameObject>();
    public List<GameObject> myDogHList = new List<GameObject>();
    public List<GameObject> myDogCageList = new List<GameObject>();
    private int t = 0;
    public int tMax = 200;

    public void DoggoSpawn()
    {
        t+=1;

        if (t >= tMax)
        {
            int i = Random.Range(0, 3);
            if (i == 0)
            {
                GameObject spawned = Instantiate(myDogList[Random.Range(0, myDogList.Count)], new Vector3(-12, -2.1f, 0), Quaternion.identity);
                spawned.transform.SetParent(this.transform);
                spawned.AddComponent<Dog>();
            }
            else if(i == 1)
            {
                GameObject spawned = Instantiate(myDogHList[Random.Range(0, myDogHList.Count)], new Vector3(-12, -1.9f, 0), Quaternion.identity);
                spawned.transform.SetParent(this.transform);
                spawned.AddComponent<Dog>();
            } else
            {
                GameObject spawned = Instantiate(myDogCageList[Random.Range(0, myDogCageList.Count)], new Vector3(-12, -4.4f, 0), Quaternion.identity);
                spawned.transform.SetParent(this.transform);
                spawned.AddComponent<Dog>();
            }
            t = 0;
        }
    }
}
