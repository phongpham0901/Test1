using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateController : MonoBehaviour
{

    private IPlayerState playerStateController;

    [Inject]
    public void Construct(IPlayerState playerStateController)
    {
        this.playerStateController = playerStateController;
    }

   
    // Update is called once per frame
    private void Update()
    {
        playerStateController.MovingState();
    }
}
