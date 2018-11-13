using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private float EnemySpeeed = 10f;

    private Transform target;
    private int WaypointIndex = 0;

	// Use this for initialization
	void Start () {

        target = LoadWaypoint.Waypoints[0];

	}
	
	// Update is called once per frame
	void Update () {

        Vector2 direction = target.position - transform.position;
        //Move Enemy
        transform.Translate(direction.normalized * EnemySpeeed * Time.deltaTime, Space.World);
        
        //Change Direction
        if (Vector2.Distance(transform.position, target.position) <= 0.4f) 
        {
            GetNextWaypoint();
        }

	}

    void GetNextWaypoint()
    {
        //Check waypoint, if it's the lasst, then Destroy
        if (WaypointIndex >= LoadWaypoint.Waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        
        WaypointIndex++;
        target = LoadWaypoint.Waypoints[WaypointIndex];
    }

}
