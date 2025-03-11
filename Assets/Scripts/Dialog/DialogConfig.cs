using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
//对话配置
namespace Dialog
{
    [CreateAssetMenu(fileName = "DialogConfig", menuName = "游戏配置/对话配置/对话数据配置", order = 0)]
    public class DialogConfig : ScriptableObject
    {
        [ListDrawerSettings(ShowIndexLabels = true,ShowPaging = false)]
        public List<DialogStepConfig> StepList =new List<DialogStepConfig>();
    }
}

