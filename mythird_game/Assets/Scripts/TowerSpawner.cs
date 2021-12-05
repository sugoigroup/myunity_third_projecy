using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private TowerTemplate towerTemplate;
    // [SerializeField] private GameObject towerPrefab;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private SystemTextViewr systemTextViewr;

    // [SerializeField] private int towerBuildGold = 50;
    [SerializeField] private PlayerGold playerGold;
    
    public void SpawnTower(Transform tileTransform)
    {
        if (towerTemplate.weapon[0].cost > playerGold.CurrentGold)
        {
            systemTextViewr.PrintText(SystemType.Money);
            return;
        }
        
        Tile tile = tileTransform.GetComponent<Tile>();
        if (tile.IsBuildTower)
        {
            systemTextViewr.PrintText(SystemType.Build);
            return;
        }

        tile.IsBuildTower = true;
        playerGold.CurrentGold -= towerTemplate.weapon[0].cost;

        Vector3 position = tileTransform.position + Vector3.back;
        
        GameObject clone = Instantiate(towerTemplate.towerPrefab, position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner, playerGold, tile);
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
