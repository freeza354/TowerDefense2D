using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Attributes for Bullet")]
    public float bulletSpeed;
    public float bulletDamage;

    public static float bulletDamagePublic;
    private Transform target;

    private void Start()
    {
        bulletDamagePublic = bulletDamage;
    }

    // Update is called once per frame
    void Update () {
		
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Vector2 dir = target.position - transform.position;
        float distanceSpeed = bulletSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(gameObject.transform.position, target.position, distanceSpeed);

	}

    public void HitTarget()
    {
        //Destroy(gameObject);
    }

    public void ChaseTarget(Transform _target)
    {
        target = _target;
    }

}
