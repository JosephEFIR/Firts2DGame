using Scripts.Player;
using Scripts.Services;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<DayNightService>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}