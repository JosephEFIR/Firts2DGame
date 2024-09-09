using Scripts.Enums;
using Scripts.Root;
using Zenject;

namespace Scripts.UI.Buttons
{
    public class MenuButton : BaseUIButton
    {
        [Inject] private SceneLoader _sceneLoader;
        protected override void OnClick()
        {
            _sceneLoader.LoadScene(ESceneType.Menu);
        }
    }
}