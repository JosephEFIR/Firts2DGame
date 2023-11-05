using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace First2DGame
{
    public class Reference : MonoBehaviour
    {
        private Canvas _canvas;
        private HealthUIView _healthUIView;
        private GameObject _heart;
        private GameObject _restartButton;

        public Canvas CanvasRef
        {
            get
            {
                _canvas = FindObjectOfType<Canvas>();
                return _canvas;
            }
            set => _canvas = value;
        }
        
        public HealthUIView HealthUI 
        {
            get
            {
                if(_healthUIView == null)
                {
                    _healthUIView = FindObjectOfType<HealthUIView>();
                }
                return _healthUIView;
            }
            set => _healthUIView = value;
        }

        public GameObject Heart
        {
            get
            {
                if (_heart == null)
                {
                    GameObject heartPrefab = Resources.Load<GameObject>("UI/Heart");
                    _heart = Instantiate(heartPrefab, HealthUI.transform);
                }
                else if (_heart != null)
                {
                    GameObject lastHeart = _healthUIView.Hearts.Last();
                    
                    GameObject heartPrefab = Resources.Load<GameObject>("UI/Heart");
                    _heart = Instantiate(heartPrefab, HealthUI.transform);
                    _heart.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(lastHeart.transform.position.x + 50F, lastHeart.transform.position.y,lastHeart.transform.position.z), Quaternion.identity);
                }

                return _heart;
            }
            set => _heart = value;
        }

        public GameObject RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    GameObject restartButtonPrefab = Resources.Load<GameObject>("UI/RestartButton");
                    _restartButton = Instantiate(restartButtonPrefab, CanvasRef.transform);
                }
                return _restartButton;
            }
            set => _restartButton = value;
        }
    }
}