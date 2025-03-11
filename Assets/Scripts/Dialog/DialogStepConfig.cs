using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public class DialogStepConfig
    {
        //是否是玩家
        [LabelText("是否是玩家")]public bool ISPlayer;
        
        //对话内容
        [HideLabel,Multiline(2)]public string DialogText;
        
        //对话开始时要执行的事件
        public List<IEvent_Dialog> StartEvents=new List<IEvent_Dialog>() ;
        //对话结束时要执行的事件
        public List<IEvent_Dialog> EndEvents=new List<IEvent_Dialog>() ;
    }
}