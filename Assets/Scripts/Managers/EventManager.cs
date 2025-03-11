using System.Collections;
using System.Collections.Generic;
using Event;
using UnityEngine;
//事件管理器

public enum EventType
{
    Dialog,//对话事件
    EnterNpc,//可以与npc交互事件
    ExitNpc,//离开npc事件
}

public class EventManager : Singleton<EventManager>
{
      private Dictionary<EventType, List<IEvent>> eventListeners=new Dictionary<EventType, List<IEvent>>();

      public void AddListener(EventType eventType, IEvent eventListener)
      {
          if (eventListeners == null)
          {
              Debug.LogError("添加事件为空");
              return;
          }

          if (eventListeners.ContainsKey(eventType))
          {
              eventListeners[eventType].Add(eventListener);
          }
          else
          {
              eventListeners.Add(eventType, new List<IEvent>(){eventListener});
          }
      }
      
      public void RemoveListener(EventType eventType, IEvent eventListener)
      {
          if (eventListeners == null)
          {
              Debug.LogError("移除事件为空");
              return;
          }

          if (eventListeners.ContainsKey(eventType))
          {
              eventListeners[eventType].Remove(eventListener);
          }
      }

      public void Excete(EventType eventType)
      {
          if (eventListeners.ContainsKey(eventType))
          {
              foreach (var listener in eventListeners[eventType])
              {
                  listener.Execute();
              }
          }
          else
          {
              Debug.LogError("没有事件监听");
          }
      }
}
