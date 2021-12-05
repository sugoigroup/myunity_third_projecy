using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private int towerBuildGold = 50;
    [SerializeField] private PlayerGold playerGold;
    
    public void SpawnTower(Transform tileTransform)
    {
        if (towerBuildGold > playerGold.CurrentGold)
        {
            return;
        }
        
        Tile tile = tileTransform.GetComponent<Tile>();
        if (tile.IsBuildTower)
        {
            return;
        }

        tile.IsBuildTower = true;
        playerGold.CurrentGold -= towerBuildGold;
        
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
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
