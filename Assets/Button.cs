using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void onClick()
    {
        Debug.Log("����");

    }


    bool Pressed = false;
    public void onDown()
    {
        Pressed = true;
    }

    public void onUp()
    {
        Pressed = false;
    }

    void Update()
    {
        if (Pressed) Debug.Log("������ ������");
    }
}
