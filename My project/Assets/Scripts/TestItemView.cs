using GameFoundation.Scripts.AssetLibrary;
using GameFoundation.Scripts.UIModule.MVP;
using GameFoundation.Scripts.UIModule.Utilities.LoadImage;
using GameFoundation.Scripts.Utilities.ObjectPool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItemModel {
    public int Scale;
    public bool ImageFromLocal;
    public string imageURl;
    public int rotation;
}

public class TestItemView : TViewMono
{
    public Rigidbody rig;
    public Image img;
    public Transform transformRotation;

}

public class TestItemPresenter : BaseUIItemPresenter<TestItemView, TestItemModel>
{
    private readonly LoadImageHelper loadImageHelper;

    public TestItemPresenter(IGameAssets gameAssets,LoadImageHelper loadImageHelper) : base(gameAssets)
    {
        this.loadImageHelper = loadImageHelper;
    }

    public override async void BindData(TestItemModel param)
    {
        if (param.ImageFromLocal)
        {
            this.View.img.sprite = await this.loadImageHelper.LoadLocalSprite(param.imageURl);
        }
        else {
        this.View.img.sprite=await this.loadImageHelper.LoadSpriteFromUrl(param.imageURl);
        }

        this.View.rig.mass = param.Scale;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
