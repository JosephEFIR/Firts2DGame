using System.Collections.Generic;
using System.Linq;
using Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.UI
{
    public class HealthUI : MonoBehaviour
    {
        public List<GameObject> Hearts = new List<GameObject>();
        private Reference _reference = new Reference();

        private void OnEnable()
        {
            EventManager._onAddHealthUI += AddHealthUI;
            EventManager._onTakeDamageUI += TakeDamageUI;
            EventManager._onDeathUI += DeathUI;
        }

        private void OnDisable()
        {
            EventManager._onAddHealthUI -= AddHealthUI;
            EventManager._onTakeDamageUI -= TakeDamageUI;
            EventManager._onDeathUI -= DeathUI;
        }
        
        private void AddHealthUI(int value)
        {
            for (int i = 0; i < value; i++)
            {
                Hearts.Add(_reference.Heart);
            }
        }

        private void TakeDamageUI(int value)
        {

            if (Hearts.Count == 0)
            {
                Hearts.Clear();
            }
            else
            {
                for (int i = 0; i < value; i++)
                {
                    var lastHeart = Hearts.Last();
                    Destroy(lastHeart);
                    Hearts.Remove(lastHeart);
                }
            }
        }

        private void DeathUI()
        {
            _reference = new Reference();
            _reference.RestartButton.SetActive(true);
        }
    }
}

