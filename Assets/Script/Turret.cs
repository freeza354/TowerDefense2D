﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    
    [Header("Attribute for Bullet Spawn")]
    public Transform target;
    public GameObject bulletPrefab;
    public Transform FireTarget;

    [Header("Attribute for Turrets")]
    public float Range = 15f;
    public float FireDelay = 2f;
    public float FireRate = 0.5f;
    public int TurretPrice = 250;

    private string EnemyTag = "Enemy";
    private float TurnSpeed = 8f;

    public static int TurretPricePublic = 0;
    // Use this for initialization
    void Start () {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        if (TurretPricePublic == 0)
        {
            TurretPricePublic = TurretPrice;
        }
        else
        {
            TurretPrice = TurretPricePublic;
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion LookRotate = Quaternion.Euler(new Vector3(0f, 0f, -(rotZ + 90)));

        //Activate this with Quaternion.Euler(Rotate) in the rotation
        Vector3 Rotate = Quaternion.Lerp(transform.rotation, LookRotate, TurnSpeed * Time.deltaTime).eulerAngles;

        this.transform.rotation = Quaternion.Euler(Rotate);

        if(FireDelay <= 0f)
        {
            Shoot();
            FireDelay = 1f / FireRate;
        }

        FireDelay -= Time.deltaTime;

	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void Shoot()
    {
        GameObject bulletTemp = (GameObject)Instantiate(bulletPrefab, FireTarget.position, FireTarget.rotation);
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
            float distanceToEnemy = Vector2.Distance(this.transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if(nearestEnemy != null && shortestDistance <= Range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    
}
