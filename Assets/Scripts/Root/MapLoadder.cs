using Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Root
{
    public class MapLoadder
    {
        public void LoadMap(EMapType _type)
        {
            switch (_type)
            {
                case EMapType.Forest:
                    SceneManager.LoadScene(1);
                    break;
                default:
                    Debug.LogWarning("Сцена/Карта не выбрана");
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}