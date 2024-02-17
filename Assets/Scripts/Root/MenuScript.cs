using Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Root
{
    public class MenuScript : MonoBehaviour
    {
        private MapLoadder _mapLoadder;

        private void Awake()
        {
            _mapLoadder = new MapLoadder();
        }

        private void UnloadMenu()
        {
            SceneManager.UnloadScene(0);
        }
            
        public void LoadFirstMap()
        {
            _mapLoadder.LoadMap(EMapType.Forest);
            UnloadMenu();
        }
    }
}