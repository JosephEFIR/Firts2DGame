using System.Collections.Generic;
using UnityEngine;

namespace First2DGame
{
    public class HealthUIView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _hearts;

        public List<GameObject> Hearts { get => _hearts; set => _hearts = value; }
    }
}

