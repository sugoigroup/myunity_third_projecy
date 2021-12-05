using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyHPSliderPrefab;
    [SerializeField] private Transform canvasTransform;

    [SerializeField] private float spawnTime;

    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private PlayerGold playerGold;
    
    
    private List<Enemy> enemyList;

    public List<Enemy> EnemyList => enemyList;

    private void Awake()
    {
        enemyList = new List<Enemy>();
        StartCoroutine("SpanEnemy");
    }

    private IEnumerator SpanEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.Setup(this, wayPoints);
            enemyList.Add(enemy);

            SpawnEnemyHPSlider(clone);

            yield return new WaitForSeconds(spawnTime);
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
