using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doggo : MonoBehaviour
{
    //DOGS
    public List<GameObject> myDogList = new List<GameObject>();

    public void DoggoSpawn()
    {
        GameObject spawned = Instantiate(myDogList[Random.Range(0,3)], new Vector3(Random.Range(465, 645 + 1), Random.Range(205, 405 + 1), 0), Quaternion.identity);
    }
}
