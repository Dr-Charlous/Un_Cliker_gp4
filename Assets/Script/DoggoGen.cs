using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoGen : MonoBehaviour
{
    //DOGS
    public List<GameObject> myDogList = new List<GameObject>();
    public List<GameObject> myDogHList = new List<GameObject>();

    public void DoggoSpawn()
    {
        int i = Random.Range(0, 2);
        if(i == 0)
        {
            GameObject spawned = Instantiate(myDogList[Random.Range(0, myDogList.Count)], new Vector3(-12, 0, 0), Quaternion.identity);
            spawned.transform.SetParent(this.transform);
            spawned.AddComponent<Dog>();
        } else
        {
            GameObject spawned = Instantiate(myDogHList[Random.Range(0, myDogHList.Count)], new Vector3(-12, 0.5f, 0), Quaternion.identity);
            spawned.transform.SetParent(this.transform);
            spawned.AddComponent<Dog>();
        }
    }
}
