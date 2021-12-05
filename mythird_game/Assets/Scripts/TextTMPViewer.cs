using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class TextTMPViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textPlayerHP;
        [SerializeField] private PlayerHP playerHp;
        [SerializeField] private TextMeshProUGUI textPlayerGold;
        [SerializeField] private PlayerGold playerGold;
        [SerializeField] private TextMeshProUGUI textWave;
        [SerializeField] private WaveSystem waveSystem;
        [SerializeField] private TextMeshProUGUI textEnemyCount;
        [SerializeField] private EnemySpawner enemySpawner;

        private void Update()
        {
            textPlayerHP.text = playerHp.CurrentHP + "/" + playerHp.MaxHP;
            textPlayerGold.text = playerGold.CurrentGold.ToString();
            textWave.text = waveSystem.CurrentWave + "/" + waveSystem.MaxWave;
            textEnemyCount.text = enemySpawner.CurrentEnemyCount + "/" + enemySpawner.MaxEnemyCount;
        }
    }
}