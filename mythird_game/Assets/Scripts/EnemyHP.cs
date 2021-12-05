using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyHP : MonoBehaviour
    {
        [SerializeField] private float maxHP;
        private float currentHP;
        private bool isDie = false;
        private Enemy enemy;
        private SpriteRenderer spriteRenderer;

        public float MaxHP => maxHP;
        public float CurrentHP => currentHP;

        private void Awake()
        {
            currentHP = maxHP;
            enemy = GetComponent<Enemy>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void TakeDamage(float damage)
        {
            if (isDie) return;

            currentHP -= damage;
            StopCoroutine("HitAplhaAnimation");
            StartCoroutine("HitAplhaAnimation");

            if (currentHP <= 0)
            {
                isDie = true;
                enemy.OnDie(EnemyDestoryType.kill);
            }
        }

        private IEnumerator HitAplhaAnimation()
        {
            Color color = spriteRenderer.color;

            color.a = 0.4f;
            spriteRenderer.color = color;

            yield return new WaitForSeconds(0.05f);

            color.a = 1.0f;
            spriteRenderer.color = color;
        }
    }
}