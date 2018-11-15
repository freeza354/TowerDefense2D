using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    
    public static Transform target;
    public GameObject bulletPrefab;
    public Transform FireTarget;

    [Header("Attribute for Turrets")]
    public float range = 15f;    
    public float FireCountdown = 0f;
    public float FireRate = 1f;

    private string EnemyTag = "Enemy";
    private float TurnSpeed = 2f;



    // Use this for initialization
    void Start () {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        dir.Normalize();

        float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion LookRotate = Quaternion.Euler(new Vector3(0f, 0f, -(rotZ + 90)));
        Vector3 Rotate = Quaternion.Lerp(transform.rotation, LookRotate, TurnSpeed * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(Rotate);

        if(FireCountdown <= 0f)
        {
            Shoot();
            FireCountdown = 1f / FireRate;
        }

        FireCountdown -= Time.deltaTime;

	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject bulletTemp = (GameObject)Instantiate(bulletPrefab, FireTarget);
        Bullet bullet = bulletTemp.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.ChaseTarget(target);
        }

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    
}
