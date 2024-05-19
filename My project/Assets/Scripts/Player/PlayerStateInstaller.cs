using UnityEngine;
using Zenject;

public class PlayerStateInstaller : MonoInstaller<PlayerStateInstaller>
{
    public Transform playerTransform;
    public float moveSpeed = 5.0f;

    public override void InstallBindings()
    {
        Container.Bind<Transform>().FromInstance(playerTransform).AsSingle();
        Container.Bind<float>().FromInstance(moveSpeed).AsSingle();
        Container.Bind<IPlayerState>().To<PlayerStateMove>().AsSingle();
    }
}
