using Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Root
{
    public class MenuScript : MonoBehaviour
    {
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = new SceneLoader();
        }

        private void UnloadMenu()
        {
            SceneManager.UnloadScene(0);
        }
            
        public void LoadFirstMap()
        {
            _sceneLoader.LoadScene(ESceneType.Forest);
            UnloadMenu();
        }
    }
}