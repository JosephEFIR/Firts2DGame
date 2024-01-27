using Scripts.Managers;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
         Container.BindInterfacesAndSelfTo<EventManager>().AsSingle().NonLazy();
    }
}