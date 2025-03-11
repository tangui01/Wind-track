using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取人物输入
/// </summary>
public class PlayerInput : MonoBehaviour
{
     private Vector2 _moveDirection = Vector3.zero;

     public Vector2 MoveDirection { get { return _moveDirection; }  }

     private void Update()
     {
          _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
     }
}
