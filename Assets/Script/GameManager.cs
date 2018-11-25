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

    [Header("Game Settings")]
    public float HealthOrgan;
    public float CellsPoint;

    [Header("Turrets Build Settings")]
    public GameObject Turrets;
    public Transform ParentPos;

    [Header("UI Settings")]
    public Text TurretPriceText;
    public Text MoneyText;
    public Text SpawnerSign;
    public Canvas CanvasParent;

    public static float HealthOrganPublic;

    public static float CellPointPublic;
    private bool canBuild, isClicking;
    private bool isFirstWave = true;
    
	// Use this for initialization
	void Start () {

        HealthOrganPublic = HealthOrgan;
        canBuild = false;
        CellPointPublic = CellsPoint;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        //Update money
        CellsPoint = CellPointPublic;

        //Update UI
        if(Turret.TurretPricePublic == 0)
        {
            TurretPriceText.text = "" + 250;
        }
        else
        {
            TurretPriceText.text = "" + Turret.TurretPricePublic;
        }

        MoneyText.text = "" + CellsPoint;
        SpawnerSign.text = "Wave " + (WaveCounter + 1);

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

        //Build Turrets
        isClicking = Input.GetMouseButtonDown(0);

        if(canBuild == true && isClicking == true && CellsPoint >= Turret.TurretPricePublic)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = 0;
            ParentPos.position = MousePos;

            CellPointPublic -= (float)Turret.TurretPricePublic;

            Instantiate(Turrets, ParentPos.transform.position, ParentPos.transform.rotation);

            canBuild = false;
            return;
        }

	}

    public void BuyTurrets()
    {
        if (canBuild == false)
        {
            canBuild = true;
        }
        else
        {
            canBuild = false;
        }
    }

    IEnumerator StartNextWave()
    {
        if(!isFirstWave)
        {
            EnemyAI.EnemyHealthPublic += 25 * Mathf.Pow((WaveCounter + 1), (float)1.12);
            EnemyAI.EnemyDamagePublic += 5 * Mathf.Pow((WaveCounter + 1), (float)1.12);

            float PriceTemp = Mathf.Floor(250 + (30 * Mathf.Pow((WaveCounter + 1), (float)1.12)));
            Turret.TurretPricePublic = Mathf.FloorToInt(PriceTemp);
        }

        Instantiate(SpawnerSign, CanvasParent.transform);

        yield return new WaitForSeconds(5f);
        StartCoroutine(SpawnWave());

    }

    IEnumerator SpawnWave()
    {
        if (isFirstWave)
        {
            EnemySpawnIndex += 0;
            isFirstWave = false;
        }

        else
        {
            EnemySpawnIndex += ((WaveCounter + 1) * 2);
        }

        for (int i = 0; i < EnemySpawnIndex + 1; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, new Vector3(SpawnPosition.transform.position.x, Random.Range(-6f, 6f), 0), SpawnPosition.transform.rotation);
    }

}
