using System.Collections.Generic;
using UnityEngine;

namespace First2DGame
{
    [CreateAssetMenu(fileName = "SpriteAnimConfig", menuName = "Configs/SpriteAnimConfig")]
    public class SpriteAnimConfig : ScriptableObject
    {
        [SerializeField]
        private List<SpriteSequence> _sequences;

        public List<SpriteSequence> Sequences => _sequences;


    }
}