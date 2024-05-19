using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldModel:BaseItemModel {
    public bool status;
}
public class ItemWorldView : BaseItemWorld
{
    public GameObject obj;
}

public class ItemWorldPresenter : BaseItemWorldPresenter<ItemWorldView, ItemWorldModel>
{
    public override void BindData(ItemWorldModel model)
    {
        this.view.obj.SetActive(model.status);
    }
}
