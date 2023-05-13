using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering state");
        stateMachine.Animator.Play("Idle");

    }
    public override void Tick(float deltime)
    {
        Debug.Log("idlestate:: tick method");
        if (_xInput != 0)
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGroundDectected())
        {
            Debug.Log("button pressed");
            stateMachine.SwitchState(new PlayerJumpState(stateMachine));
            return;
        }

        if (_dashButton)
        {
            stateMachine.SwitchState(new PlayerDashState(stateMachine));
        }

        if (!IsGroundDectected())
        {
            
            stateMachine.SwitchState(new PlayerAirState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {

    }

    
}
