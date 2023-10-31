using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using Object = UnityEngine.Object;

namespace First2DGame
{
    public class Reference : MonoBehaviour
    {
        private HealthUIView _healthUIView;
        private GameObject _heart;

        public HealthUIView HealthUI 
        {
            get
            {
                if(_healthUIView == null)
                {
                    _healthUIView = Object.FindObjectOfType<HealthUIView>();
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
                    GameObject heartPrefab = Resources.Load<GameObject>("Prefabs/UI/Heart");
                    _heart = Object.Instantiate(heartPrefab, HealthUI.transform);
                }
                else if (_heart != null)
                {
                    GameObject lastHeart = _healthUIView.Hearts.Last();
                    
                    GameObject heartPrefab = Resources.Load<GameObject>("Prefabs/UI/Heart");
                    _heart = Object.Instantiate(heartPrefab, HealthUI.transform);
                    _heart.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(lastHeart.transform.position.x + 50F, lastHeart.transform.position.y,lastHeart.transform.position.z), Quaternion.identity);
                }

                return _heart;
            }
            set => _heart = value;
        }
        
    }
}