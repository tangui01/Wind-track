using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManine 
{
    public IsState currentState { get; private set; }

    public void InitState(IsState initialState)
    {
        currentState = initialState;
    }
    public void ChangeState(IsState newState)
    {
        if (newState!= currentState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
}
