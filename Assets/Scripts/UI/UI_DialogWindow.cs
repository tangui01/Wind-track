using System;
using System.Collections;
using System.Collections.Generic;
using Dialog;
using Event;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogWindow : MonoBehaviour
{
      private Player _player;
      private NPC  currentNPC;
      
      private DialogConfig config;
      private int Stepindex;

      #region UI
      private Text NameText;
      private Text DialogText;
      private Image Headimg;
      private Text Tips;
      private bool HasNextDialog=>Stepindex<config.StepList.Count-1;//是否有下一条对话
      #endregion


      private void Awake()
      {
            NameText=transform.Find("Content_Bg/NameText").GetComponent<Text>();
            DialogText=transform.Find("Content_Bg/DialogText").GetComponent<Text>();
            Headimg=transform.Find("Content_Bg/Headimg").GetComponent<Image>();
            Tips=transform.Find("Content_Bg/Tips").GetComponent<Text>();
      }

      public void StartDialog(Player player, NPC npc,DialogConfig config,int Stepindex)
      {
            _player = player;
            currentNPC = npc;
            this.config = config;
            this.Stepindex = Stepindex;
            Debug.Log("开始对话");
            player.ISmove = false;
            StartDialogStep(config);
      }

      private void StartDialogStep(DialogConfig config)
      {
            StartCoroutine(DoDialogStep(config));
      }

      private void Close()
      {
            _player.ISmove = true;
            _player = null;
            currentNPC = null;
            config = null;
            Stepindex = 0;
            StopAllCoroutines();
            gameObject.SetActive(false);
      }

      private IEnumerator DoDialogStep(DialogConfig config)
      {
            if (config.StepList[Stepindex].ISPlayer)
            {
                  NameText.text = _player.roleDialog.name;  
                  Headimg.sprite = _player.roleDialog.roleIcon;
            }
            else
            {
                  NameText.text = currentNPC.roleDialog.name;
                  Headimg.sprite = currentNPC.roleDialog.roleIcon;
            }
            Headimg.SetNativeSize();
            DialogText.text = config.StepList[Stepindex].DialogText;
            // 开始事件
            DoStepEventsBlock(config.StepList[Stepindex].StartEvents);
            yield return DoStepEventsNonBlocks(config.StepList[Stepindex].StartEvents);
            //出现文字
            yield return DoDialogContentEffect(config.StepList[Stepindex].DialogText);
            //等待点击
            while (!Input.anyKeyDown) yield return null;
            //结束事件
            DoStepEventsBlock(config.StepList[Stepindex].EndEvents);
            yield return DoStepEventsNonBlocks(config.StepList[Stepindex].EndEvents);
            //下一条或者结束
            if (HasNextDialog)
            {
                  Stepindex++;
                  StartDialog(_player, currentNPC, config, Stepindex);
            }
            else
            {
                  Close();
            }

      }

      private void DoStepEventsBlock(List<IEvent_Dialog> events)
      {
            for (int i = 0; i < events.Count; i++)
            {
                  events[i].Execute();
            }
      }
      private IEnumerator DoStepEventsNonBlocks(List<IEvent_Dialog> events)
      {
            for (int i = 0; i < events.Count; i++)
            {
                  IEnumerator enumerator = events[i].ExecuteBlocking();
                  if (enumerator != null)
                  {
                      yield return  enumerator;
                  }
            }
      }

      IEnumerator DoDialogContentEffect(string content)
      {
            string text = "";
            DialogText.text = text;
            Tips.gameObject.SetActive(false);
            foreach (char item in content)
            {
                  text += item;
                  yield return new WaitForSeconds(0.1f);
                  DialogText.text = text;
            }
            Tips.gameObject.SetActive(true);
      }
}
