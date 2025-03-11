using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
     protected StateManine manine;
     //角色数据
     public RoleDialog roleDialog;
     public Animator Anim { get;protected set; }

     protected virtual void Awake()
     {
          manine = new StateManine();
          Anim = GetComponentInChildren<Animator>();
     }

     protected virtual void Update()
     {
          manine.currentState.Update();
     }
}
