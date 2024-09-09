using Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Root
{
    public class SceneLoader
    {
        public void LoadScene(ESceneType _type)
        {
            switch (_type)
            {
                case ESceneType.Menu:
                    SceneManager.LoadScene(0);
                    SceneManager.UnloadScene(SceneManager.GetActiveScene());
                    break;
                case ESceneType.Forest:
                    SceneManager.LoadScene(1);
                    SceneManager.UnloadScene(SceneManager.GetActiveScene());
                    break;
                default:
                    Debug.LogWarning("Сцена/Карта не выбрана");
                    SceneManager.UnloadScene(SceneManager.GetActiveScene());
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}