using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyHPSliderPrefab;
    [SerializeField] private Transform canvasTransform;

    //[SerializeField] private float spawnTime;

    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private PlayerGold playerGold;
    
    private Wave currentWave;
    private int currentEnemyCount;
    private List<Enemy> enemyList;

    public List<Enemy> EnemyList => enemyList;
    public int CurrentEnemyCount => currentEnemyCount;
    public int MaxEnemyCount => currentWave.maxEnemyCount;

    private void Awake()
    {
        enemyList = new List<Enemy>();
        //StartCoroutine("SpanEnemy");
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        StartCoroutine("SpawnEnemy");
        currentEnemyCount = currentWave.maxEnemyCount;
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnEnemyCount = 0;
        
        while (spawnEnemyCount < currentWave.maxEnemyCount)
        {
            //GameObject clone = Instantiate(enemyPrefab);
            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.Setup(this, wayPoints);
            enemyList.Add(enemy);

            SpawnEnemyHPSlider(clone);

            spawnEnemyCount++;

            yield return new WaitForSeconds(currentWave.spawnTime);
        }
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
        
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
        
    }

    public void DestroyEnemy(EnemyDestoryType enemyDestoryType, Enemy enemy, int gold)
    {
        if (enemyDestoryType == EnemyDestoryType.Arrive)
        {
            playerHP.TakeDamage(1);
        } else if (enemyDestoryType == EnemyDestoryType.kill)
        {
            playerGold.CurrentGold += gold;
        }

        currentEnemyCount--;
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
