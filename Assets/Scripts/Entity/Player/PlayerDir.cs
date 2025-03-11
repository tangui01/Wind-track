using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
//主角的朝向
public enum PlayerDirType
{
    Left,
    Right
}
public class PlayerDir : MonoBehaviour
{
    //是否朝右
    public PlayerDirType currentDir = PlayerDirType.Left;

    public void SetDir(PlayerDirType targetDir)
    {
        currentDir = targetDir;
    }
}
