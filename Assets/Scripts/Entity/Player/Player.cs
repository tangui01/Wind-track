using System;
using System.Collections;
using System.Collections.Generic;
using Dialog;
using UnityEngine;
using Util;

public class Player : Entity
{
     public static Player player { get; private set; }

      public PlayerInteract  Interact { get;private set; }
     public PlayerInput PlayerInput { get; private set;}
     public PlayerDir Dir { get; private set;}
     
     public Rigidbody2D Rb { get; protected set;}


     public NPC NPC;
     
     public bool ISmove=true;
    
     #region States

     public PlayerIdleState IdleState { get; private set; }
     public PlayerWalkState WalkState { get; private set; }

     #endregion
     protected override void Awake()
     {
         base.Awake();
         player = this;
         PlayerInput = GetComponent<PlayerInput>();
         Interact = GetComponent<PlayerInteract>();
         Dir = GetComponent<PlayerDir>();
         Rb = GetComponent<Rigidbody2D>();
         IdleState = new PlayerIdleState(AniBoolNameUtil.Idle,Anim,this,manine);
         WalkState = new PlayerWalkState(AniBoolNameUtil.Walk,Anim,this,manine);
         manine.InitState(IdleState);
     }
     public void Move()
     {
         Rb.velocity = PlayerInput.MoveDirection * ConstantUtil.playerSpeed;
         Filp();
     }

     protected override  void Update()
     {
         base.Update();
         GetInteractInput();
     }

     //交互
     public void GetInteractInput()
     {
         if (Input.GetKeyDown(KeyCode.E))
         {
             Debug.Log("开始交互");
             DialogConfig config = DialogManger.Instance.GetDialog(DialogDataNameUtil.NPC1Dialog);
             UIManager.Instance.OPenDialog(Player.player,NPC,config,0);
         }
     }
     public void SetISMove(bool isMove)
     {
         ISmove = isMove;
     }

     public void Filp()
     {
         //判定是否需要翻转
         if (PlayerInput.MoveDirection.Equals(Vector2.right)&&Dir.currentDir.Equals(PlayerDirType.Left))
         {
              transform.localScale = new Vector3(-1, 1, 1);
              Dir.SetDir(PlayerDirType.Right);
         }
         else if (PlayerInput.MoveDirection.Equals(Vector2.left)&&Dir.currentDir.Equals(PlayerDirType.Right))
         {
              transform.localScale = new Vector3(1, 1, 1);
              Dir.SetDir(PlayerDirType.Left);
         }
     }

     private void OnTriggerStay2D(Collider2D other)
     {
         if (other.gameObject.CompareTag(Util.TagUtil.NpcTag))
         {
             Debug.Log("现在你可以开始和NPC对话了");
         }
     }
     
     private void OnTriggerExit2D(Collider2D other)
     {
         if (other.gameObject.CompareTag(Util.TagUtil.NpcTag))
         {
             Debug.Log("你离开了NPC的视线");
             EventManager.Instance.Excete(EventType.ExitNpc);
         }
     }
}
