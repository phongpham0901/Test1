using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using Cysharp.Threading.Tasks;
using Zenject;
using GameFoundation.Scripts.Utilities.LogService;
using GameFoundation.Scripts.UIModule.ScreenFlow.Managers;
using GameFoundation.Scripts.AssetLibrary;
using GameFoundation.Scripts.Utilities.ObjectPool;

public class PhongScreenModel
{
    public string nameScreen;
}


public class PhongScreenView : BaseView
{
    public TextMeshProUGUI txtNameScreen;
    public Button btnChangeScreen;
    public TestItemView testItemView;
}

[ScreenInfo(nameof(PhongScreenView))]
public class PhongScreenPresenter : BaseScreenPresenter<PhongScreenView, PhongScreenModel>
{
    private readonly GamePlayPresenter gamePlayPresenter;
    private readonly IGameAssets gameAssets;
    private readonly DiContainer diContainer;
    private readonly IScreenManager screenManager;

    private TestItemPresenter testItemPresenter;
    private TestItemPresenter presenterFromObjectPool;
    public PhongScreenPresenter(SignalBus signalBus,GamePlayPresenter gamePlayPresenter,IGameAssets gameAssets,DiContainer diContainer, ILogService logger, IScreenManager screenManager) : base(signalBus, logger)
    {
        this.gamePlayPresenter = gamePlayPresenter;
        this.gameAssets = gameAssets;
        this.diContainer = diContainer;
        this.screenManager = screenManager;
    }

    protected override void OnViewReady()
    {
        base.OnViewReady();
        this.View.btnChangeScreen.onClick.AddListener(this.OnClick);
        
    }

    private void OnClick()
    {
        this.gamePlayPresenter.StartGame();
        this.Logger.Log($"Start game");
        //this.screenManager.OpenScreen<MainScreenPresenter, MainScreenModel>(new MainScreenModel() { TestValue = 100});
    }

    public override UniTask BindData(PhongScreenModel screenModel)
    {
        this.View.txtNameScreen.text = $"{screenModel.nameScreen}";
        this.CreateItemFromViewHasAlreadyHaveInScreenView();
        //this.CreateFromObjectPool();
        return UniTask.CompletedTask;
    }

    private async void CreateFromObjectPool() {
        var viewPrefab = await this.gameAssets.LoadAssetAsync<GameObject>("TestItemView");
        var viewInstance = viewPrefab.Spawn();
        viewInstance.transform.SetParent(this.View.transform);
        viewInstance.transform.localPosition = Vector3.zero;
        viewInstance.transform.localScale = Vector3.one;
        this.testItemPresenter ??= this.diContainer.Instantiate<TestItemPresenter>();
        this.testItemPresenter.SetView(viewInstance.GetComponent<TestItemView>());
        this.testItemPresenter.BindData(new TestItemModel()
        {
            Scale = 10,
            imageURl= "https://th.bing.com/th/id/R.845f3fded0e146b66fc66fa3d6467083?rik=%2bcd4RskYHZAigw&riu=http%3a%2f%2fdpnow.com%2fimages%2fPhotoFixChallenge%2fDSC00092.JPG&ehk=c06%2bl0ErTk%2byGB4xDJ1kyBrGChLXUj3yIgKZ4csQYt0%3d&risl=1&pid=ImgRaw&r=0"
        });
    }

    private void CreateItemFromViewHasAlreadyHaveInScreenView()
    {
        //if(this.testItemPresenter==null)
        this.testItemPresenter ??= this.diContainer.Instantiate<TestItemPresenter>();
        this.testItemPresenter.SetView(this.View.testItemView);
        this.testItemPresenter.BindData(new TestItemModel()
        {
            Scale = 5,
            ImageFromLocal=true,
            imageURl="icon_test"
        });
    }

    public override void Dispose()
    {
        base.Dispose();
        this.presenterFromObjectPool.View.gameObject.Recycle();
        this.presenterFromObjectPool?.Dispose();
        this.testItemPresenter?.Dispose();
    }
}
