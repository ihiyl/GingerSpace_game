using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Transform player;

    private float timebtwShot;
    public float startTimeBtwShots = 1f;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timebtwShot = startTimeBtwShots;
    }





    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (timebtwShot <=0)
        {
            Instantiate(gameObject, player.position, Quaternion.identity);
            timebtwShot = startTimeBtwShots;
        }
        else 
        {
            timebtwShot -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player");
        {
            Destroy(gameObject);
        }
    }

    
}


