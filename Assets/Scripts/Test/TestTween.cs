using DG.Tweening;
using UnityEngine;

namespace Test
{
    public class TestTween : MonoBehaviour
    {
        private Transform _point;

        private void Start()
        {
            gameObject.transform.DOLocalMoveY( gameObject.transform.position.y + 500, 10F);
        }
    }
}