using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public float speed;
	 Rigidbody m_Rigidbody;
	  public float damage = 1;
    

    void Start () {
		 m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        speed = 10.0f;
	}
	
	void Update () {
       //transform.Translate(transform.forward * speed * Time.deltaTime);
		m_Rigidbody.velocity = -transform.forward * speed;
	}
	void OnCollisionEnter(Collision collision) {
   {
       Enemy enemy = collision.gameObject.GetComponent<Enemy>();

       // If we hit an enemy, then reduce it's health
       if (enemy != null)
       {
           enemy.TakeDamage(damage);
            }
       }

       // Remove the bullet from the scene, we don't need it any more
       Destroy(gameObject);
   }
}
