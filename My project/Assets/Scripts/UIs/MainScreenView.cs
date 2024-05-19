using Cysharp.Threading.Tasks;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
using GameFoundation.Scripts.Utilities.LogService;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class  MainScreenModel
{
    public int TestValue;
}

public class MainScreenView : BaseView
{
    public TextMeshProUGUI txt;
    public Button btnOpenScreenPhong;
}

[ScreenInfo(nameof(MainScreenView))]
public class MainScreenPresenter : BaseScreenPresenter<MainScreenView, MainScreenModel>
{
    private readonly IScreenManager screenManager;
    public MainScreenPresenter(SignalBus signalBus, ILogService logger, IScreenManager screenManager) : base(signalBus, logger)

    {
        this.screenManager = screenManager;
    }

    protected override void OnViewReady()
    {
        base.OnViewReady();
        this.View.btnOpenScreenPhong.onClick.AddListener(this.OnClick);
    }

    private void OnClick()
    {

        this.screenManager.OpenScreen<PhongScreenPresenter, PhongScreenModel>(new PhongScreenModel() {
        nameScreen=nameof(MainScreenView)});
    }

    public override UniTask BindData(MainScreenModel screenModel)
    {
        this.View.txt.text = $"{screenModel.TestValue}";
        return UniTask.CompletedTask;
    }
}
