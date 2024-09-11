using Scripts.Player;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Buttons
{
    public class BackSpawnButton : BaseUIButton
    {
        [Inject] private PlayerMoveController _playerMove;
        
        protected override void OnClick()
        {
            _playerMove.transform.position = new Vector3(0,0,1);
        }
    }
}