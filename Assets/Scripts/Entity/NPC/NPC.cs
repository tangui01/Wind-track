using System;
using System.Collections;
using System.Collections.Generic;
using Dialog;
using Event;
using UnityEngine;
using Util;

public class NPC : MonoBehaviour
{
    private GameObject Interact;

    public RoleDialog roleDialog;
    private void Awake()
    {
        Interact = transform.Find("Interact_Tips").gameObject;
        Interact.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(TagUtil.PlayerTag))
        {
               Interact.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagUtil.PlayerTag))
        {
            Interact.SetActive(true);
        }
    }
}
