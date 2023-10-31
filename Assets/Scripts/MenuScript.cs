using UnityEngine;
using UnityEngine.SceneManagement;

namespace First2DGame
{
    public class MenuScript : MonoBehaviour
    {
        public void LoadFirstLVL()
        {
            SceneManager.LoadScene(1);
            SceneManager.UnloadScene(0);
        }
    }
}