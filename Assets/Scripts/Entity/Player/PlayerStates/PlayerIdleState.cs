using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(string AniBoolName, Animator Ani, Entity _entity, StateManine stateManine) : base(AniBoolName, Ani, _entity, stateManine)
    {
    }
    public override void Update()
    {
        base.Update();
        if (!player.PlayerInput.MoveDirection.Equals(Vector2.zero)&&player.ISmove)
        {
            _stateManine.ChangeState(player.WalkState);
        }
    }
}
