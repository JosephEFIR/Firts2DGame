using Scripts.Enums;
using Scripts.Managers;
using Scripts.Root;
using UnityEngine;
using Zenject;

namespace Scripts.UI
{
    public sealed class DeathUI : BaseUI
    {
        [Inject] private MapLoadder _mapLoadder;
        [SerializeField] private GameObject _restartButton;
        
        public override void Initialize()
        {
            EventManager._onDeathUI += Show;
        }
        
        protected override void OnDisable()
        {
            EventManager._onDeathUI -= Show;
        }

        private void OnDeath()
        {
            _mapLoadder.LoadMap(EMapType.Forest);
        }
    }
}