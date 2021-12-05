using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public enum SystemType{ Money =0, Build}
    public class SystemTextViewr : MonoBehaviour
    {
        private TextMeshProUGUI textSystem;
        private TMPAlpha tmpAlpha;

        private void Awake()
        {
            textSystem = GetComponent<TextMeshProUGUI>();
            tmpAlpha = GetComponent<TMPAlpha>();
        }

        public void PrintText(SystemType type)
        {
            switch (type)
            {
                case SystemType.Money:
                    textSystem.text = "System : Not money";
                    break;
                case SystemType.Build:
                    textSystem.text = "System : Invalid build tower";
                    break;
            }            
            tmpAlpha.FadeOut();
        }
    }
}