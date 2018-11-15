using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float bulletSpeed = 5f;

	// Update is called once per frame
	void Update () {
		
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceSpeed = bulletSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceSpeed)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceSpeed);

	}

    public void HitTarget()
    {
        //Destroy(gameObject);
    }

    public void ChaseTarget(Transform _target)
    {
        _target = target;
    }

}
