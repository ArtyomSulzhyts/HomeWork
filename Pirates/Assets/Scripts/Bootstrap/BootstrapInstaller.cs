using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private App app;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<App>().FromInstance(app).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<GameStatsManager>().AsSingle().NonLazy();
    }
}
