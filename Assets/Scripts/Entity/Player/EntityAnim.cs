using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnim : MonoBehaviour
{
    public Animator animator { get;private set; }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
}
