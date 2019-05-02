using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f; 
    [HideInInspector]//hides variable in inspector; 
    public float speed;

    public float startHealth = 100f;
    private float health; 

    public Image healthBar; 

    public int worth = 50;

    void Start()
    {
        speed = startSpeed;
        health = startHealth; 
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/ startHealth; //messing with health bar if our health is 100 and divided by starthealth 100 equals 1. 
        if (health <= 0)
        {

            Die();
        }
    }

    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    }
    void Die()
    {
        PlayerStats.Money += worth;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    

}
