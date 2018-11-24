using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("Wave Settings")]
    public GameObject EnemyPrefab;
    public GameObject SpawnPosition;
    public float SpawnCooldownInterval = 5f;
    public float WaveTimerInterval;
    public int WaveCounter = 0;

    [Header("Target Enemy Settings")]


    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private float timeDelaySpawner = 5f;

    private float WaveIntervalPrivate;
    private float cooldown = 2f;
    private int enemySpawnIndex = 0;

	// Use this for initialization
	void Start () {

        WaveIntervalPrivate = WaveTimerInterval;

	}
	
	// Update is called once per frame
	void Update () {
		
        if(WaveTimerInterval <= 0f)
        {
            StartCoroutine(SpawnWave());
            WaveTimerInterval = timeDelaySpawner;
        }

        WaveTimerInterval -= Time.deltaTime;
	}

    IEnumerator SpawnWave()
    {
        enemySpawnIndex++;
        for (int i = 0; i < enemySpawnIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}
