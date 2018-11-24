using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [Header("Enemy Option")]
    public GameObject TargetPosition;
    public float EnemyHealth;
    public float EnemyBounty;
    public float EnemyMoveSpeed;

    private float randPosY;

	// Use this for initialization
	void Start () {

        StartCoroutine(MoveBehavior());

	}
	
	// Update is called once per frame
	void Update () {
        //Please Activate One of The Following
        //Originally, i thought it's better without Lerp

        //Without Lerp
        transform.Translate(new Vector3(TargetPosition.transform.position.x, randPosY, 0) * EnemyMoveSpeed * Time.deltaTime);

        //With Lerp
        //transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(TargetPosition.transform.position.x, randPosY, 0), EnemyMoveSpeed * Time.deltaTime);

        if(gameObject.transform.position.y >= 8f)
        {
            randPosY = Random.Range(-8f, -1f);
        }
        if(gameObject.transform.position.y <= -8f)
        {
            randPosY = Random.Range(1f, 8f);
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
