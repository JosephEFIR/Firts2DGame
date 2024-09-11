using Scripts.Managers;
using Scripts.Player;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerMoveController>().FromComponentInHierarchy().AsSingle().NonLazy(); //TODO Rework this
        Container.BindInterfacesAndSelfTo<UIManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        //Container.BindInterfacesAndSelfTo<DayNightService>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}