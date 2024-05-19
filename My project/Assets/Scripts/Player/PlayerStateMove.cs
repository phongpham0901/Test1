using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateMove : IPlayerState
{
    private Transform _playerTransform;
    private float _moveSpeed;

    [Inject]
    public PlayerStateMove(Transform playerTransform, float moveSpeed)
    {
        _playerTransform = playerTransform;
        _moveSpeed = moveSpeed;
    }

    public void MovingState()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _moveSpeed * Time.deltaTime;
        _playerTransform.Translate(movement);
    }
}
