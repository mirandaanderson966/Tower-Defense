using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy; 
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
        enemy = GetComponent<Enemy>();
        target = waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);// same speed is normalized * the actual time. 

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)//moves towards it until next wavepoint
        {
            getNextWaypoint();
        }

        enemy.speed = enemy.startSpeed; //if target isnt slowing us then we go back to our noraml speed. 
    }

    void getNextWaypoint()
    {

        if (wavepointIndex >= waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;//makes it move from 1 to 2 to 3.. 
        target = waypoints.points[wavepointIndex];
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

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
