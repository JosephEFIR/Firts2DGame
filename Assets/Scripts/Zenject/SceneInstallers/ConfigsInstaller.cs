using Scripts.Configs;
using UnityEngine;
using Zenject;

public class ConfigsInstaller : MonoInstaller
{
    [Header("Configs")]
    [SerializeField] private PlayerConfig _playerConfig;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_playerConfig).AsSingle().NonLazy();
    }
}