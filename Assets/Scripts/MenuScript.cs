using UnityEngine;
using UnityEngine.SceneManagement;

namespace First2DGame
{
    public class MenuScript : MonoBehaviour
    {
        private FirstMapLoadder _firstMapLoadder;

        private void UnloadMenu()
        {
            SceneManager.UnloadScene(0);
        }
            
        public void LoadFirstMap()
        {
            _firstMapLoadder.LoadMap();
            UnloadMenu();
        }
    }
}