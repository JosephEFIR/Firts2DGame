using Scripts.Root;
using Zenject;

public class GlobalInsataller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MapLoadder>().AsSingle().NonLazy();
    }
}