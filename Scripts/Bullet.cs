
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70;
    public int damage = 50;
    public float explosionRadius = 0f; 
    public GameObject ImpactEffect; 

    public void Seek (Transform _target)
    {
        target = _target; 
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return; 
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
     
        GameObject effectins = (GameObject) Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectins, 2f);

        if (explosionRadius > 0f)
        {
            explode();
        }else
        {
            Damage(target);
        }
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null) {
            e.TakeDamage(damage);
        }
       
    }
}
