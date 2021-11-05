using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    public PlayerParametrs player;

    Image healthBat;
    public float maxHealth = 100f;
    

    void Start()
    {
        healthBat = GetComponent<Image>();
        player.hp = maxHealth;
    }

    
    void Update()
    {
        healthBat.fillAmount = player.hp / maxHealth;
    }
}
