using ProjectTools;
using Scripts.Configs;
using Scripts.Enums;
using UnityEngine;
using Zenject;

public class ConfigsInstaller : MonoInstaller
{
    [Header("Configs")]
    [SerializeField] private PlayerConfig _playerConfig;

    [SerializeField] private SerializableDictionary<EEnemyType, EnemyConfig> _enemyConfigs;

    public override void InstallBindings()
    {
        Container.BindInstance(_playerConfig).AsSingle().NonLazy();
        Container.BindInstance(_enemyConfigs).AsSingle().NonLazy();
    }
}