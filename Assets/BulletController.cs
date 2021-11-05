using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 diretion;
    public float speed = 5f;


    public void Update() 
    {
        transform.Translate(diretion * Time.deltaTime * speed);
    }
}
