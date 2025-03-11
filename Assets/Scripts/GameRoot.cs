using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏进入根节点
/// </summary>
public class GameRoot : Singleton<GameRoot>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DialogManger.Instance.Init();
    }
}
