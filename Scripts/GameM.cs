using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour {

    private bool gameEnded = false;
    public GameObject gameOverUi;
    public Transform GunTransform;
    public float damage = 1;
    public float range = 1000f;
    //public float weaponRange = 200f;
    public float Bullet_Forward_Force = 500;
   //public float hitForce = 100f; 
    //public float fireRate = .25f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    //public int Speed = 20; 
    //private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    private AudioSource gunAudio; 
    private LineRenderer LaserLine; 
    private float nextFire;
    // Update is called once per frame

    private bool m_isWaiting = false;
    private bool m_canShoot = true;
    public float m_secondsBetweenShots;


        void Start(){
        LaserLine = GetComponent<LineRenderer> ();
        //fpsCam = GetComponent<Camera> ();
         }
        void Update () {
        Debug.Log(m_canShoot);
        if (gameEnded)
            return;
        if (Input.GetKeyDown("e")){
            EndGame(); 
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            if (!m_isWaiting) { 
                if (m_canShoot)
                {
                    
                    Debug.Log("gunna shoot");
                    ShootGun();
                }
                else
                {
                    Debug.Log("waiting");
                    StartCoroutine(Wait());
                    m_isWaiting = true;
                }
            }
            
           // nextFire = Time.time + fireRate; 
            //artCoroutine(ShotEffect());
            //Vector3 rayOrgin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            //RaycastHit hit;
           // LaserLine.SetPosition(0,firePoint.position);
           // if(Physics.Raycast(GunTransform.position, GunTransform.forward, out hit, range))
           // {
           //     LaserLine.SetPosition(1, hit.point);
           // }else {
           //    LaserLine.SetPosition(1, GunTransform.forward * weaponRange);
           // }
            
        }
	}
    /*private IEnumerator ShotEffect(){
        LaserLine.enabled = true; 
        yield return shotDuration; 
        LaserLine.enabled = false; 
    }*/
    void EndGame()
    {
        gameEnded = true;
        gameOverUi.SetActive(true);
        Debug.Log("Game Over!");
    }
    
    void ShootGun()
    {
        m_canShoot = false;
        //nextFire = Time.time + fireRate; 
        
        
        RaycastHit hit;
        //Debug.Log("hit shoot");
        if(Physics.Raycast(GunTransform.position, GunTransform.forward, out hit, range))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            //StartCoroutine(ShotEffect());
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(bulletPrefab,firePoint.transform.position, firePoint.transform.rotation) as GameObject;
           //Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
            Rigidbody Temporty_RigidBody;
            Temporty_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporty_RigidBody.AddRelativeForce(-Vector3.forward * Bullet_Forward_Force);
            Destroy(Temporary_Bullet_Handler, 2.0f);

            //GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //Bullet bullet = bulletGo.GetComponent<Bullet>();
            //bulletGo.GetComponent<Rigidbody>().velocity = bulletGo.transform.forward * 6;
            //Enemy enemy = hit.transform.GetComponent<Enemy>();
           
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
               
            }
        }
    IEnumerator Wait()
    {

        Debug.Log("Waiting");

        yield return new WaitForSeconds(m_secondsBetweenShots);
        m_isWaiting = false;
        m_canShoot = true;

    }

}

