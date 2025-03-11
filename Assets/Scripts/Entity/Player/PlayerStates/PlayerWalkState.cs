using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(string AniBoolName, Animator Ani, Entity _entity, StateManine stateManine) : base(AniBoolName, Ani, _entity, stateManine)
    {
    }

    public override void Update()
    {
        base.Update();
        player.Move();
        if (player.PlayerInput.MoveDirection.Equals(Vector2.zero))
        {
            _stateManine.ChangeState(player.IdleState);
        }
    }
}
