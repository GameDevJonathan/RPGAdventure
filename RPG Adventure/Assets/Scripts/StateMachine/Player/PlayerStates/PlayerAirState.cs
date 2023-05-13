using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    Rigidbody2D rb;

    public PlayerAirState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        this.rb = stateMachine.rigidBody;

    }

    public override void Enter()
    {
        
        stateMachine.Animator.Play("JumpFall");
    }
    public override void Tick(float deltaTime)
    {
        
        stateMachine.Animator.SetFloat("yVelocity", rb.velocity.y);
        if (_dashButton)
        {
            stateMachine.SwitchState(new PlayerDashState(stateMachine));
        }
        if (IsGroundDectected())
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting state");
    }

}
