using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float lookRadius = 10f;
    public Transform target;
    public string playerTag = "Player";
    public Transform enemyBody;
    public float turnSpd = 10f;

    public float fireRate = 1f;
    private float fireCooldown = 0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(playerTag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestTarget = null;

        foreach (GameObject Player in targets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, Player.transform.position);

            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = Player;
            }
        }

        if (nearestTarget != null && shortestDistance <= lookRadius)
        {
            target = nearestTarget.transform; 
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(enemyBody.rotation, lookRotation, Time.deltaTime * turnSpd).eulerAngles;
        enemyBody.rotation = Quaternion.Euler (rotation.x, rotation.y, 0f);

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime; 

    }

    void Shoot()
    {
       GameObject bulletHostile = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
       bulletProperties bullet = bulletHostile.GetComponent<bulletProperties>();

        if (bullet != null)
        {
            bullet.Chase(target);
        }
    }
    
 

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
