using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy; 
    [Header ("Fire Settgings")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public float range = 15f;

    [Header ("Enemy Settings")]
    public string enemyTag = "Enemy";
    public Transform partToRotate; //reference to part to rotate. 
    public float turnSpeed = 10f;
    public ParticleSystem particleEffect;
    public float slowPercent = .5f;

    public Light impactLight;
    public int damageOverTime = 50; //damage enemy 30 per second

    [Header ("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool useLaser = false;
    public GameObject Laserblender;
    public LineRenderer lineRenderer; 

   


	// Use this for initialization
	void Start () {
      // Laserblender.gameObject.GetComponent<MeshRenderer>().enabled = false;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

	}
        void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //finds all of our enemies. 
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null; 
        

        foreach (GameObject enemy in enemies)//for each enemy that we have found. 
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)// if this is the shorest distance that we have found. 
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy; // this is the closest enemy. 
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }else
        {
            target = null; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerStats.Money >= 10)
        //{
            //TurretNode.gameObject.GetComponent<MeshRenderer>().enabled = true;
          //  Debug.Log ("you got monely.........");
            //Laserblender.SetActive(true);
        //}
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    particleEffect.Stop();
                    impactLight.enabled = false; 
                }
                   
            }
            return;
        }
       
            
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {



            if (fireCountDown <= 0f)//if we are ready to shoot. 
            {
                Shoot();
                fireCountDown = 1f / fireRate;

            }
            fireCountDown -= Time.deltaTime;

        }
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);//deals with turning. 
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //euler angles is xyz lerping makes things smooth out so making the turn radius be smoother. 
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);//makes it only rotate around the Y. 
    }
    void Laser()
    {
       targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercent);
       

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            particleEffect.Play();
            impactLight.enabled = true;
        }
           
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;//makes impacteffect goes behind the enemy
        particleEffect.transform.position = target.position + dir.normalized;//radius is of enemy is 1 so have to move location .5 back. 

        particleEffect.transform.rotation = Quaternion.LookRotation(dir);

      
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target); 
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);//draws the green range. 
    }
}
