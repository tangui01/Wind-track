using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BookPanel : MonoBehaviour
{
    public void OpenBook()
    {
        gameObject.SetActive(true);
    }

    public void CloseBook()
    {
        gameObject.SetActive(false);
    }
}
