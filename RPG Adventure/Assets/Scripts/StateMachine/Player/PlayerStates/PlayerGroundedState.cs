using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

    }
    public override void Tick(float deltaTime)
    {
        Debug.Log("grounded state update");
    }

    public override void Exit()
    {

    }

    private void Update()
    {
        Debug.Log("update method");
    }



}
