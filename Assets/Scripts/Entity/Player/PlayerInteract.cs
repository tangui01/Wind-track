using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
      //是否可以交互
      private bool ISCanInteract = false;

      private void Start()
      {
            EventManager.Instance.AddListener(EventType.EnterNpc, new IEvent{onEvent = (args) => {ISCanInteract = true;}});
            EventManager.Instance.AddListener(EventType.ExitNpc, new IEvent{onEvent = (args) => {ISCanInteract = false;}});
      }
      public bool CanInteract()
      {
            return ISCanInteract;
      }
      
}
