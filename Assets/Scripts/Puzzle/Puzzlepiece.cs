using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

/// <summary>
/// 拼图碎片的脚本
/// </summary>
public class Puzzlepiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 startPosition;
    private RectTransform rectTransform;
    private Canvas canvas;

    private bool ISCommplete = false;
    private Vector2 TarMovePos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void Init(Vector2 targetPosition)
    {
        TarMovePos = targetPosition;
        rectTransform.anchoredPosition =new Vector2(Random.Range(-400,800),Random.Range(-500,-200));
    }

    private void Start()
    {
        startPosition = rectTransform.anchoredPosition;
        rectTransform.localScale = Vector3.one*0.8f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ISCommplete)
        {
            return;
        }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //拖拽结束后;
        if (ISMoveTarget())
        {
            rectTransform.anchoredPosition = TarMovePos;
            ISCommplete = true;
            rectTransform.DOScale(1f, 0.2f);
        }
        else
        {
            rectTransform.anchoredPosition = startPosition;
        }
    }

    /// <summary>
    /// 判断是否移动到目标位置
    /// </summary>
    /// <returns></returns>
    private bool ISMoveTarget()
    {
        if (Mathf.Abs(rectTransform.anchoredPosition.x - TarMovePos.x) < 40f &&
            Mathf.Abs(rectTransform.anchoredPosition.y - TarMovePos.y) < 40f)
        {
            return true;
        }

        return false;
    }
}