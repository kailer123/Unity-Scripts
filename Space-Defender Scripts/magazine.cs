using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine : MonoBehaviour
{
    public int leftInMag = 7;
    float timer = 2f;
    Comunicacion com;

    void Awake()
    {
        com = GetComponent<Comunicacion>();
    }
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            leftInMag++;
            timer = 2f;
        }
        if (leftInMag == 0)
        {
            com.canShoot = false;
        }
        else
        {
            com.canShoot = true;
        }
        leftInMag = Mathf.Clamp(leftInMag, 0, 7);
    }
}
