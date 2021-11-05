using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    public bool isFire = false;
    public GameObject bullet;
    public Transform bulletStartPos;
    Vector2 direction;

    public void Update()
    {
        direction = Vector2.zero;
        direction.x = LeftJoystickControl.Horizontal();
        direction.y = LeftJoystickControl.Vertical();

        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }

        Debug.Log(direction);
    }

    public void ActivateShootingRay() 
    {
        isFire = true;
        StartCoroutine(StartFire());
    }

    public void DeActevate() 
    {
        isFire = false;
    }

    public IEnumerator StartFire() 
    {
        while(isFire)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject bulletFire = Instantiate(bullet, bulletStartPos.position, Quaternion.identity);
            bulletFire.GetComponent<BulletController>().diretion = direction;
        }
    }
}
