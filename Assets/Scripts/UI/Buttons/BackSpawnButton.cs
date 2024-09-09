using Scripts.Player;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Buttons
{
    public class BackSpawnButton : BaseUIButton
    {
        [Inject] private PlayerController _player;
        
        protected override void OnClick()
        {
            _player.transform.position = new Vector3(0,0,1);
        }
    }
}