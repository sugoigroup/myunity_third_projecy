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

        private void Update()
        {
            textPlayerHP.text = playerHp.CurrentHP + "/" + playerHp.MaxHP;
            textPlayerGold.text = playerGold.CurrentGold.ToString();
        }
    }
}