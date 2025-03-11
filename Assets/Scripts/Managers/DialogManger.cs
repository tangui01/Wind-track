using System;
using System.Collections;
using System.Collections.Generic;
using Dialog;
using UnityEngine;
using Util;

/// <summary>
/// 对话管理器
/// </summary>
public class DialogManger : Singleton<DialogManger>
{
      private Dictionary<string, DialogConfig>   DialogConfigDic = new Dictionary<string, DialogConfig>();

      public void Init()
      {
            DialogConfig[] dialogConfigs = Resources.LoadAll<DialogConfig>(PathUtil.DialogConfigPath);
            foreach (DialogConfig dialogConfig in dialogConfigs)
            {
                  DialogConfigDic.Add(dialogConfig.name, dialogConfig);
            }
      }

      public DialogConfig GetDialog(string name)
      {
            if (DialogConfigDic.ContainsKey(name))
            {
                  return DialogConfigDic[name];
            }
            else
            {
                  Debug.LogError("没有找到对话配置：" + name);
                  return null;
            }
      }
}
