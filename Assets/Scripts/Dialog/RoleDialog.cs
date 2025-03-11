using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
/// <summary>
/// 对话角色配置
/// </summary>
[CreateAssetMenu(fileName = "RoleDialog", menuName = "游戏配置/对话配置/角色数据配置", order = 0)]
public class RoleDialog : SerializedScriptableObject
{
     [LabelText("角色名称")]public string roleName;
     [LabelText("角色图标")]public Sprite roleIcon;
}

