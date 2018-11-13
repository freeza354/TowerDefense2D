using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private float timeDelaySpawner = 5f;
    [SerializeField]
    private Text WaveCounter;


    private float cooldown = 2f;
    private int enemySpawnIndex = 0;

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
        WaveCounter.text = enemySpawnIndex.ToString();
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
