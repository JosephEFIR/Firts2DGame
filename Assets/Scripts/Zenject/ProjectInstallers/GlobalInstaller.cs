using Scripts.Root;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MapLoadder>().AsSingle().NonLazy();
    }
}