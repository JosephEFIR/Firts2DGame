using Scripts.Managers;
using Scripts.Player;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<HealthSystem>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}