using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 

public class Fire : MonoBehaviour {
	 public GameObject projectilePrefab;
    GameObject instantiatedProjectile;
    public Transform projectileLaunchPoint;
    public Transform GunTransform;
    public float damage = 1;
     public float Bullet_Forward_Force = 20;
     GameObject Temporary_Bullet_Handler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            //ShootGun();
		}
	}
	//[Command]
    void ShootGun()
    {
        RaycastHit hit;
         if(Physics.Raycast(GunTransform.position, GunTransform.forward, out hit))
        {
        GameObject bulletGo = (GameObject)Instantiate(projectilePrefab, projectileLaunchPoint.position, projectileLaunchPoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bulletGo.GetComponent<Rigidbody>().velocity = bulletGo.transform.forward * 6;
        Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        if (NetworkServer.active)
        {
            NetworkServer.Spawn(instantiatedProjectile);
           
        }

}
    }
    }
