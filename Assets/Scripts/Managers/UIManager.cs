using System.Collections;
using System.Collections.Generic;
using Dialog;
using UnityEngine;
//UI管理器
public class UIManager : Singleton<UIManager>
{
        public UI_DialogWindow UI_DialogWindow;
        
        public void OPenDialog(Player player, NPC npc,DialogConfig config,int Stepindex)
        {
                if (UI_DialogWindow == null)
                {
                        Debug.Log("UI_DialogWindow is null");
                        return;
                }
                UI_DialogWindow.gameObject.SetActive(true);
                UI_DialogWindow.StartDialog(player, npc, config,Stepindex);
        }
}
