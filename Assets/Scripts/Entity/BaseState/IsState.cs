using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态基类
/// </summary>
public abstract class IsState 
{
    //对话名字
    private string AniBoolName;
    private readonly Animator _ani;
    protected Entity _entity;
    
    protected StateManine _stateManine;

    public IsState(string AniBoolName, Animator Ani,Entity _entity, StateManine stateManine)
    {
        this.AniBoolName = AniBoolName;
        this._ani = Ani;
        this._entity = _entity;
        this._stateManine = stateManine;
    }
    
    public virtual void Enter()
    {
        _ani.SetBool(AniBoolName, true);
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        _ani.SetBool(AniBoolName, false);
    }
}
