using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;


    public PlayerState(string AniBoolName, Animator Ani, Entity _entity, StateManine stateManine) : base(AniBoolName, Ani, _entity, stateManine)
    {
        player = (Player)_entity;
    }
}
