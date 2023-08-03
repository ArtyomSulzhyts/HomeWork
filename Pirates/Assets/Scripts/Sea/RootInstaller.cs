using UnityEngine;
using Zenject;

namespace Pirates 
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private Ship playerShip;

        public override void InstallBindings()
        {
            Container.Bind<IShip>().FromInstance(playerShip).AsSingle();
            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GamePlayController>().AsSingle().NonLazy();
        }
    }
}