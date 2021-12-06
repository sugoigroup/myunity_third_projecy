using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Slow : MonoBehaviour
    {
        private TowerWeapon towerWeapon;

        private void Awake()
        {
            towerWeapon = GetComponentInParent<TowerWeapon>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy"))
            {
                return;
            }

            Movement2D movement2D = other.GetComponent<Movement2D>();

            movement2D.MoveSpeed -= movement2D.MoveSpeed * towerWeapon.Slow;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy"))
            {
                return;
            }
            other.GetComponent<Movement2D>().ResetMoveSpeed();
        }
    }
}