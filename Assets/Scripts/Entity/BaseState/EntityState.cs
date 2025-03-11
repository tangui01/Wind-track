using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState : IsState
{
    protected EntityState(string AniBoolName, Animator Ani, Entity _entity, StateManine stateManine) : base(AniBoolName, Ani, _entity, stateManine)
    {
    }
}
