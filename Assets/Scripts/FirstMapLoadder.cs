using UnityEngine;
using UnityEngine.SceneManagement;

namespace First2DGame
{
    public class FirstMapLoadder : MonoBehaviour
    {
        public void LoadMap()
        {
            SceneManager.LoadScene(1);
        }
    }
}