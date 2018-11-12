using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private float EnemySpeeed = 10f;

    private Transform target;
    private int WavepointIndex = 0;

	// Use this for initialization
	void Start () {

        target = LoadWaypoint.Waypoints[0];

	}
	
	// Update is called once per frame
	void Update () {

        Vector2 direction = target.position - transform.position;

        transform.Translate(direction.normalized * EnemySpeeed * Time.deltaTime, Space.World);

	}
}
