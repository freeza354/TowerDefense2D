using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("Wave Settings")]
    public GameObject EnemyPrefab;
    public GameObject SpawnPosition;
    public float SpawnCooldownInterval = 5f;
    public int WaveCounter = 0;
    public int EnemySpawnIndex = 5;
    public static int EnemyIndex;

    [Header("Organ Settings")]
    public float HealthOrgan;

    public static float HealthOrganPublic;

    private bool isFirstWave = true;
    
	// Use this for initialization
	void Start () {

        HealthOrganPublic = HealthOrgan;
        StartCoroutine(StartNextWave());

	}
	
	// Update is called once per frame
	void Update () {
		
        if(EnemyIndex == 0)
        {
            //Start Next Wave
            StartCoroutine(StartNextWave());
            EnemyIndex = EnemySpawnIndex;
        }

        if(HealthOrganPublic <= 0)
        {
            //GameOver;
        }

	}

    IEnumerator StartNextWave()
    {
        StartCoroutine(SpawnWave());
        yield return new WaitForSeconds(5f);
    }

    IEnumerator SpawnWave()
    {
        if (isFirstWave)
        {
            EnemySpawnIndex += 0;
        }

        else
        {
            EnemySpawnIndex += ((WaveCounter + 1) * 2);
        }

        for (int i = 0; i < EnemySpawnIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, new Vector3(SpawnPosition.transform.position.x, Random.Range(-8f, 8f), 0), SpawnPosition.transform.rotation);
    }

}
