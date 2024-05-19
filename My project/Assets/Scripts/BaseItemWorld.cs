using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItemModel { }

public abstract class BaseItemWorld : MonoBehaviour
{
}

public abstract class BaseItemWorldPresenter<Tview, Tmodel> where Tmodel : BaseItemModel where Tview : BaseItemWorld
{

    protected Tview view;
    protected Tmodel model;

    public virtual void SetView(Tview view)
    {

        this.view = view;
    }

  public abstract void BindData(Tmodel model);
}
