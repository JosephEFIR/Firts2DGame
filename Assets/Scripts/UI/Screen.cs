using UnityEngine;

namespace Scripts.UI
{
    public enum EScreenType
    {
        None,
        Game,
        Defeat,
        Victory,
        Inventory,
    }
    
    public class Screen : MonoBehaviour
    {
        [SerializeField] private EScreenType _screenType;

        public EScreenType ScreenType => _screenType;
    }
}