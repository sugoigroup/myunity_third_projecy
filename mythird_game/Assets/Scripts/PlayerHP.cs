using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerHP : MonoBehaviour
    {
        [SerializeField] private float maxHP = 20;
        [SerializeField] private Image imageSCreen;
        private float currentHP;

        public float MaxHP => maxHP;
        public float CurrentHP => currentHP;

        private void Awake()
        {
            currentHP = maxHP;
        }

        public void TakeDamage(float damage)
        {
            currentHP -= damage;
            
            StopCoroutine("HitAlphaAnimation");
            StartCoroutine("HitAlphaAnimation");

            if (currentHP <= 0)
            {
               // Destroy(gameObject);
            }
        }

        private IEnumerator HitAlphaAnimation()
        {
            Color color = imageSCreen.color;
            color.a = 0.4f;
            imageSCreen.color = color;

            while (color.a >= 0.0f)
            {
                color.a -= Time.deltaTime;
                imageSCreen.color = color;

                yield return null;
            }
        }
    }
}