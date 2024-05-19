using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
using GameFoundation.Scripts.UIModule.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpamleSceneInstaller :BaseSceneInstaller
{

    public override void InstallBindings()
    {
        base.InstallBindings();
        this.Container.InitScreenManually<LoadingScreenPresenter>();
        this.Container.Bind<GamePlayController>().FromComponentInHierarchy().WhenInjectedInto<GamePlayPresenter>();
        this.Container.BindInterfacesAndSelfTo<GamePlayPresenter>().AsCached().NonLazy();
        this.Container.Bind<GamePlayDataState>().AsCached().NonLazy();
    }
}
