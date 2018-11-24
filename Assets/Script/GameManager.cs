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
    public int EnemySpawnIndex = 5;

    [Header("Target Enemy Settings")]
    public float HealthOrgan;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private float timeDelaySpawner = 5f;

    public static float HealthOrganPublic;

    private float WaveIntervalPrivate;
    private float cooldown = 2f;
    private int enemySpawnIndex = 0;

	// Use this for initialization
	void Start () {

        WaveIntervalPrivate = WaveTimerInterval;
        HealthOrganPublic = HealthOrgan;

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
        EnemySpawnIndex = EnemySpawnIndex + ((WaveCounter + 1) * 2);
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
