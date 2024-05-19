using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlayController : MonoBehaviour
{
    public ItemWorldView itemview;
}

public class GamePlayPresenter:IInitializable,ITickable {
    private readonly GamePlayController view;
    private readonly DiContainer diContainer;
    private readonly GamePlayDataState gamePlayDataState;
    public GamePlayPresenter(GamePlayController view,DiContainer diContainer,GamePlayDataState gamePlayDataState)
    {
        this.view = view;
        this.diContainer = diContainer;
        this.gamePlayDataState = gamePlayDataState;
    }

    public void Initialize()
    {
       
    }

    public void StartGame() {
        var presenter = this.diContainer.Instantiate<ItemWorldPresenter>();
        presenter.SetView(this.view.itemview);
        var model = new ItemWorldModel();
        model.status = true;
        this.gamePlayDataState.cachedData.Add(presenter, model);
        presenter.BindData(model);
    }


    //Update
    public void Tick()
    {
        
    }
}
