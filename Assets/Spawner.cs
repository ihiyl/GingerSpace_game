using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Bullet; 

    public float Power;

    //public void Update()
    //{
    //    if (Input.GetButton2Down)
    //    {
     //       Ray ray = new Ray(transform.position, transform.forward);
     //       RaycastHit hit;
     //       if (Physics.Raycast(ray, out hit))
     //       {
     //           hit.rigidbody.AddForceAtPosition(ray.direction * Power, hit.point, ForceMode.Impulse);
     //           Instantiate(Bullet, hit.point, transform.rotation);
     //       }
     //   }
   // }
}
