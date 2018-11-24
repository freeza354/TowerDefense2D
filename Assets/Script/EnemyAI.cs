﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [Header("Enemy Option")]
    public GameObject TargetPosition;
    public float EnemyHealth;
    public float EnemyBounty;
    public float EnemyMoveSpeed;
    public float EnemyDamage;

    private float randPosY;
    
	// Use this for initialization
	void Start () {

        TargetPosition = GameObject.FindGameObjectWithTag("Target");
        StartCoroutine(MoveBehavior());

	}
	
	// Update is called once per frame
	void Update () {

        //Please Activate Enemies Move from one of the following
        //Originally, i thought it's better without Lerp

        //Without Lerp
        transform.Translate(new Vector3(TargetPosition.transform.position.x + 5f, randPosY, 0) * EnemyMoveSpeed * Time.deltaTime);

        //With Lerp
        //transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(TargetPosition.transform.position.x, randPosY, 0), EnemyMoveSpeed * Time.deltaTime);
        
        //Random Movement on Y axis
        if(gameObject.transform.position.y >= 8f)
        {
            randPosY = Random.Range(-8f, -1f);
        }
        if(gameObject.transform.position.y <= -8f)
        {
            randPosY = Random.Range(1f, 8f);
        }

        //Destroy Object when arrived at destination
        if(gameObject.transform.position.x >= TargetPosition.transform.position.x)
        {
            GameManager.EnemyIndex--;
            GameManager.HealthOrganPublic -= EnemyDamage;
            Destroy(gameObject);
        }

        //Destroy When HP below 0
        if(EnemyHealth <= 0)
        {
            GameManager.EnemyIndex--;
            Destroy(gameObject);
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyHealth -= Bullet.bulletDamagePublic;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator MoveBehavior()
    {
        while (true)
        {
            randPosY = Random.Range(-8f, 8f);

            yield return new WaitForSeconds(0.5f);
        }
    }

}
