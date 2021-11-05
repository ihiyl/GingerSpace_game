using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    public float startTimeFire;
    private float TimeFire;

    void start() 
    {
        TimeFire = startTimeFire;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, firePoint.position, transform.rotation);
            TimeFire = startTimeFire;
        }
        else 
        {
             TimeFire -= Time.deltaTime;
        }
    }
}
