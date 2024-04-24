using Scripts.Managers;
using Zenject;

public class ManagersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
         Container.BindInterfacesAndSelfTo<EventManager>().AsSingle().NonLazy(); //TODO ивенты можно хранить в сущности где они используются. EventManager не нужен
    }
}