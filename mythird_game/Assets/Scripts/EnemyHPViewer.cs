using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EnemyHPViewer : MonoBehaviour
    {
        private EnemyHP enemyHp;
        private Slider hpSlider;

        public void Setup(EnemyHP enemyHp)
        {
            this.enemyHp = enemyHp;
            hpSlider = GetComponent<Slider>();
        }

        private void Update()
        {
            hpSlider.value = enemyHp.CurrentHP / enemyHp.MaxHP;
        }
    }
}