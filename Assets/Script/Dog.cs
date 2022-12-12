using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float speed = 2.0f;
    int Timer = 0;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        Timer += 1;
        if (Timer == 3000)
        {
            string objectName = this.name;
            GameObject objectToDestroy = GameObject.Find(objectName);
            Destroy(objectToDestroy);
        }
    }
}
