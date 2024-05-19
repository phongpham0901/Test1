using Cysharp.Threading.Tasks;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.UI;
using System;
using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;

public class LoadingScreenView : BaseView
{
    public TextMeshProUGUI txtTest;
    public Button btnTest;
}

[ScreenInfo(nameof(LoadingScreenView))]
public class LoadingScreenPresenter : BaseScreenPresenter<LoadingScreenView>
{
    private readonly IScreenManager screenManager;

    public LoadingScreenPresenter(SignalBus signalBus,IScreenManager screenManager) : base(signalBus)
    {
        this.screenManager = screenManager;
    }

    protected override void OnViewReady()
    {
        base.OnViewReady();
        this.OpenViewAsync().Forget();
        this.View.btnTest.onClick.AddListener(this.OnClick);
    }

    private void OnClick()
    {
        this.screenManager.OpenScreen<MainScreenPresenter, MainScreenModel>(new MainScreenModel() { 
        TestValue =10});
    }

    public override  UniTask BindData()
    {
        this.View.txtTest.text = $"Hello";
        return UniTask.CompletedTask;
    }
}
