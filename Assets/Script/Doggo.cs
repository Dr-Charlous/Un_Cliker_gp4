using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doggo : MonoBehaviour
{
    //DOGS
    public List<GameObject> myDogList = new List<GameObject>();

    public void DoggoSpawn()
    {
        GameObject spawned = Instantiate(myDogList[Random.Range(0,3)], new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
        spawned.transform.SetParent(this.transform);
    }
}
