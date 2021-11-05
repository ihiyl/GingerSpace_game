using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerParametrs : MonoBehaviour
{
    public float hp;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 5;
        
        }
    }

    public void Update()
    {
        if (hp <= 0) 
        {
            SceneManager.LoadScene(3);
        }
    }
}
