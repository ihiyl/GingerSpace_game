using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycrl : MonoBehaviour
{
    public Transform center;
    public float radius = 2f, angularSped = 2f;

    float positionX, positionY, angle = 0f;


    void Update()
    {
        positionX = center.position.x + Mathf.Cos(angle) * radius;
        positionY = center.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * angularSped;

        if(angle >= 360f)
        {
            angle = 0f;
        }
    }

    public void onClick()
    {
        if (angularSped >= 2f)
        {
            angularSped = angularSped * -1f;
        }


        else 
        {
            angularSped = angularSped * -1f;
        }
        Debug.Log(angularSped);

    }

}
