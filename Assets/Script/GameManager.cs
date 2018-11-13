using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private float timeDelaySpawner = 5f;

    private float cooldown = 2f;
    private int enemySpawnIndex = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(cooldown <= 0f)
        {
            StartCoroutine(SpawnWave());
            cooldown = timeDelaySpawner;
        }

        cooldown -= Time.deltaTime;

	}

    IEnumerator SpawnWave()
    {

        for (int i = 0; i < enemySpawnIndex; i++)
        {
            SpawnEnemy();
        }
        enemySpawnIndex++;
        yield return new WaitForSeconds(0.5f);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.transform);
    }

}
